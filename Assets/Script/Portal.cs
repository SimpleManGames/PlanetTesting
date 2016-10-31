using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Portal : MonoBehaviour
{
    [HideInInspector]
    public enum PortalBehaviour
    {
        Random, Linked
    }
    public PortalBehaviour behaviour;
    public Portal toPortal;

    void Start()
    {
        if (behaviour == PortalBehaviour.Linked && toPortal == null)
            toPortal = PortalManager.instance.GetRandomPortal;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        TeleportObject otherTeleport = other.GetComponent<TeleportObject>();
        if (otherTeleport != null)
        {
            if (otherTeleport.CanTeleport)
            {
                if (behaviour == PortalBehaviour.Random)
                {
                    toPortal = PortalManager.instance.GetRandomPortal;
                    while(toPortal == this)
                        toPortal = PortalManager.instance.GetRandomPortal;
                }
                otherTeleport.SpawnEffect(toPortal.transform.position);

                otherTeleport.CanTeleport = false;
            }
        }
    }
}
