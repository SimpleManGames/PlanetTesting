using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CoreMotor : MonoBehaviour
{

    #region Variables

    #region Modifiers

    public float rotationSpeed = 5;

    public bool gravityEnabled = true;

    #endregion

    #region Components

    new protected Rigidbody2D rigidbody;

    new protected Collider2D collider;

    #endregion

    #region Properties

    protected PlanetObject closestPlanet
    { get { return PlanetManager.instance.ClosestPlanet(transform.position); } }

    protected Vector3 gravity
    { get {
            Vector3 gravity = Vector3.zero;
            foreach (PlanetObject planet in PlanetManager.instance.planets)
            {
                float dist = Vector3.Distance(transform.position, planet.transform.position);
                gravity += ((planet.transform.position - transform.position).normalized * planet.gravityStrength * rigidbody.mass * planet.rigidbody.mass) / (Mathf.Pow(dist, 2));
            }
            return gravity;
    }     }
    
    private bool _facingRight;
    public bool facingRight
    { get { return _facingRight; }

      set { if (_facingRight != value)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            _facingRight = value;
    }     }

    protected bool isGrounded
    { get { if(Physics2D.Raycast(transform.position - transform.TransformDirection(new Vector3(0, ((BoxCollider2D)collider).size.y * 0.14f, 0)), -transform.up, 0.08f)) return true;

            return false;
    }     }

    #endregion

    #endregion

    #region Functions

    #region UnityFunctions

    // Use this for initialization
    protected virtual void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
	}

    // Update is called once per frame
    protected virtual void FixedUpdate ()
    {
        if (gravityEnabled)
        {
            ApplyGravity();
            ApplyRotation();
        }
	}

    #endregion

    #region Physics

    void ApplyGravity()
    { rigidbody.AddForce(gravity); }

    void ApplyRotation()
    {        
        if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(transform.forward, -gravity.normalized)) > 5)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.forward, -gravity.normalized), Time.deltaTime * rotationSpeed);
        else
            transform.rotation = Quaternion.LookRotation(transform.forward, -gravity.normalized);
    }

    #endregion

    #endregion

}
