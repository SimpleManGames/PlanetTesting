using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class TestPlanetMovement : MonoBehaviour {

    Rigidbody2D rigid;

    void Start() {
        rigid = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, rigid.velocity, Color.red);
        rigid.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * 100);
	}
}
