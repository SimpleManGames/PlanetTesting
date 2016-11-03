using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Portal : MonoBehaviour {

    public enum PortalBehaviour { Random, Linked }
    [SerializeField]
    [Tooltip( "How the portal will act when an object enters it. " + 
        "Random will send to a random portal other than the current one. " + 
        "Linked goes to the pre-defined portal." )]
    private PortalBehaviour _behaviour;
    public PortalBehaviour Behaviour {
        get { return _behaviour; }
        set { _behaviour = value; }
    }

    [SerializeField]
    [Tooltip("The other end of the portal. " +
        "If linked behaviour; set this and it will always be connected to it. " + 
        "If the behaviour is random; the code will chose a portal to send to.")]
    private Portal _toPortal;
    public Portal ToPortal {
        get { return _toPortal; }
        set { _toPortal = value; }
    }

    void Start( ) {
        if ( Behaviour == PortalBehaviour.Linked && ToPortal == null )
            ToPortal = PortalManager.instance.GetRandomPortal;
    }

    void OnTriggerEnter2D( Collider2D other ) {
        TeleportObject otherTeleport = other.GetComponent<TeleportObject>();
        if ( otherTeleport != null ) {
            if ( otherTeleport.CanTeleport ) {
                if ( Behaviour == PortalBehaviour.Random ) {
                    ToPortal = PortalManager.instance.GetRandomPortal;
                    while ( ToPortal == this )
                        ToPortal = PortalManager.instance.GetRandomPortal;
                }
                otherTeleport.SpawnEffect( ToPortal.transform.position );
                otherTeleport.CanTeleport = false;
            }
        }
    }
}
