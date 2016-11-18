using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlanetCollision))]
public class PlanetObject : CoreObject {

    new public Rigidbody2D rigidbody;

    public float gravityStrength;

    //public float gravityRange;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        rigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    protected override void Update () {
        base.Update();
	}

    void OnDestory( ) {
        Debug.Log( "Destory" );
    }
}
