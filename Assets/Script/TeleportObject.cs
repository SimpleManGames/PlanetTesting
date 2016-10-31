using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(MeshRenderer))]
public class TeleportObject : MonoBehaviour
{
    public TeleportEffect teleportEffect;
    private float time;

    private bool _canTeleport = true;
    public bool CanTeleport
    {
        get { return _canTeleport; }
        set
        {
            _canTeleport = value;
            if (value == false) time = 0.0f;
        }
    }

    private TeleportEffect obj;
    private BoxCollider2D box2D;
    private MeshRenderer meshRend;

    void Start()
    {
        time = PortalManager.instance.teleportDelay;
        box2D = GetComponent<BoxCollider2D>();
        meshRend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _canTeleport = (time >= PortalManager.instance.teleportDelay) ? true : false;
        if (!_canTeleport) time += Time.deltaTime;

        if (obj != null)
        {
            if (obj.GetComponent<TeleportEffect>().hasArrived)
            {
                transform.position = obj.movePos;
                box2D.enabled = true;
                meshRend.enabled = true;
                Destroy(obj.gameObject);
            }
            else
            {
                box2D.enabled = false;
                meshRend.enabled = false;
            }
        }
    }

    public void SpawnEffect(Vector3 pos)
    {
        obj = Instantiate(teleportEffect.gameObject).GetComponent<TeleportEffect>();
        obj.teleportingObj = this.gameObject;
        obj.gameObject.transform.position = this.transform.position;
        obj.MoveTowards(pos);
    }
}
