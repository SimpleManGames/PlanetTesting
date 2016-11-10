using UnityEngine;
using System.Collections;

public class TeleportEffect : MonoBehaviour {

    private Vector3 _movePos;
    public Vector3 MovePosition {
        get { return _movePos; }
        set { this._movePos = value; }
    }

    [SerializeField]
    [Tooltip("The desired speed when moving between portals. " +
        "This value is locked above .001f.")]
    private float _wantedSpeed;
    public float WantedSpeed {
        get { return _wantedSpeed; }
        set { this._wantedSpeed = value; }
    }

    private float _moveSpeed;
    public float MoveSpeed {
        get { return _moveSpeed; } 
        set { this._moveSpeed = value; }
    }

    private bool _hasArrived = false;
    public bool HasArrived {
        get { return _hasArrived; }
        set { this._hasArrived = value; }
    }

    private GameObject _teleportingObj;
    public GameObject TeleportingObj {
        get {
            return _teleportingObj;
        }

        set {
            this._teleportingObj = value;
        }
    }

    void Update( ) {
        Move();
        Rotate();
        if ( MovePosition == transform.position )
            HasArrived = true;
    }

    private void Move( ) {
        float step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards( transform.position, MovePosition, step );
    }

    private void Rotate( ) {
        Vector3 target = MovePosition - transform.position;
        transform.up = Vector3.Normalize( target );
    }

    public void MoveTowards( Vector3 pos ) {
        MovePosition = pos;
        MoveSpeed = CalculateSpeed( pos );
    }

    private float CalculateSpeed( Vector3 pos ) {
        return WantedSpeed * Vector3.Distance( transform.position, pos );
    }

    void OnValidate( ) {
        WantedSpeed = Mathf.Clamp( WantedSpeed, 0.001f, int.MaxValue);
    }
}
