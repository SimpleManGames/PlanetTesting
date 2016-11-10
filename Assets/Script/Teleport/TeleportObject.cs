using UnityEngine;
using System.Collections;

[RequireComponent( typeof( BoxCollider2D ) )]
[RequireComponent( typeof( MeshRenderer ) )]
public class TeleportObject : MonoBehaviour {
    private float time;

    private bool _canTeleport = true;
    public bool CanTeleport {
        get { return _canTeleport; }
        set {
            if ((_canTeleport = value) == false )
                time = 0.000f;
        }
    }

    [SerializeField]
    [Tooltip("The prefeb of the effect that is going to be used to represent the movement between portals.")]
    private TeleportEffect _teleportEffect;
    public TeleportEffect TeleportEffect {
        get { return _teleportEffect; }
        set { this._teleportEffect = value; }
    }

    private TeleportEffect obj;
    private BoxCollider2D box2D;
    private MeshRenderer meshRend;

    void Start( ) {
        time = PortalManager.instance.TeleportDelay;
        box2D = GetComponent<BoxCollider2D>();
        meshRend = GetComponent<MeshRenderer>();
    }

    void FixedUpdate( ) {
        _canTeleport = ( time >= PortalManager.instance.TeleportDelay ) ? true : false;
        if ( !_canTeleport )
            time += Time.deltaTime;

        if ( obj != null ) {
            if ( obj.GetComponent<TeleportEffect>().HasArrived ) {
                box2D.enabled = true;
                meshRend.enabled = true;
                Destroy( obj.gameObject );
            } else {
                transform.position = obj.transform.position;
                box2D.enabled = false;
                meshRend.enabled = false;
            }
        }
    }

    public void SpawnEffect( Vector3 pos ) {
        obj = Instantiate( TeleportEffect.gameObject ).GetComponent<TeleportEffect>();
        obj.TeleportingObj = this.gameObject;
        obj.gameObject.transform.position = this.transform.position;
        obj.MoveTowards( pos );
    }
}
