using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBH : MonoBehaviour
{
    public float velocity;

    public void MoveRB(Vector3 dir)
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + velocity * Time.fixedDeltaTime * dir);
    }
}
