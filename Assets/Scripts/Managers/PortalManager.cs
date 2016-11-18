using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalManager : MonoBehaviour {
    private static PortalManager _instance;
    public static PortalManager instance { get { return _instance; } }

    private List<Portal> _portalList = new List<Portal>();
    public List<Portal> PortalList {
        get { return _portalList; }
        set { foreach ( Portal p in value ) _portalList.Add( p ); }
    }

    public Portal GetRandomPortal {
        get { return _portalList [ Random.Range( 0, _portalList.Count ) ]; }
    }
    [SerializeField]
    [Tooltip("The delay between beign able to re-enter a portal. " +
        "This value is locked above .001f.")]
    private float _teleportDelay = 3;
    public float TeleportDelay {
        get { return _teleportDelay; }
        set { this._teleportDelay = value; }
    }

    void Awake( ) {
        if ( !_instance )
            _instance = this;
        else
            Destroy( gameObject );

        foreach ( GameObject obj in GameObject.FindGameObjectsWithTag( "Portal" ) )
            _portalList.Add( obj.GetComponent<Portal>() );
    }

    public void AddPortal( Portal add ) {
        _portalList.Add( add );
    }

    void OnValidate( ) {
        TeleportDelay = Mathf.Clamp( TeleportDelay, .001f, int.MaxValue );
    }
}
