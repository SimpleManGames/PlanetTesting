using UnityEngine;
using System.Collections;

public class BulletMotor : CoreMotor {

    public Transform owner;

    public float speed;

    public float dropoff;

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Move();
    }

    void Move()
    {
        Vector2 direction;

        if (facingRight)
            direction = Vector3.right * speed;

        else
            direction = Vector3.left * speed;

        Vector2 velocity = transform.InverseTransformDirection(rigidbody.velocity);
        Vector2 velocityChange = direction - velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -speed, speed);
        velocityChange.y = -dropoff * Time.deltaTime;

        velocityChange = transform.TransformDirection(velocityChange);
        rigidbody.velocity += velocityChange;
    }
}
