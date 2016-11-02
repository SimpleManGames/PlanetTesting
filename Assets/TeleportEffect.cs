using UnityEngine;
using System.Collections;

public class TeleportEffect : MonoBehaviour
{
    [HideInInspector]
    public Vector3 movePos;
    public float speed;
    [HideInInspector]
    public bool hasArrived = false;
    [HideInInspector]
    public GameObject teleportingObj;

    void Update()
    {
        Move();
        Rotate();
        if (movePos == transform.position)
        {
            hasArrived = true;
        }
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePos, step);
    }

    private void Rotate()
    {
        Vector3 target = movePos - transform.position;
        transform.up = Vector3.Normalize(target);
    }

    public void MoveTowards(Vector3 pos)
    {
        movePos = pos;
        speed = Vector3.Distance(transform.position, pos);
    }
}
