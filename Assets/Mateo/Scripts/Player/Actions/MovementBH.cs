using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBH : MonoBehaviour
{
    public float velocity;

    public void RotateDirection2D(Vector3 dir, float initialRotation)
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - initialRotation);
    }
    public void RotateDirection2D(Vector3 dir)
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
    }
    public void RotateDirection(Vector3 dir)
    {
        transform.rotation = Quaternion.Euler(0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, 0);
    }

    public void MoveTowards(Vector3 dir)
    {
        transform.position = transform.position + velocity * dir * Time.fixedDeltaTime;
    }

    public void MoveRB(Vector3 dir)
    {
        if (!WillCollide(dir))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + velocity * Time.fixedDeltaTime * dir);
        }
    }
    public void MoveRB(Vector3 dir, float vel)
    {
        if (!WillCollide(dir))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + vel * Time.fixedDeltaTime * dir);
        }
    }

    private bool WillCollide(Vector3 dir)
    {
        return false;
    }
}
