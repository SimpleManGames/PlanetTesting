using UnityEngine;
using System.Collections;

public class TeleportObject : MonoBehaviour
{
    [HideInInspector]
    public GameObject gameObj;
    [HideInInspector]
    public float time;

    public bool canTeleport = true;

    void Update() {
        if (time >= PortalManager.instance.teleportDelay)
        {
            canTeleport = true;
        }
        else
        {
            canTeleport = false;
            time += Time.deltaTime;
        }
    }
}
