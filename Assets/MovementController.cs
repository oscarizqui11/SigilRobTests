using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private MovementBH _mb;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        _mb = GetComponent<MovementBH>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsMoving())
        {
            _mb.MoveRB(direction.normalized * direction.normalized.magnitude);
            transform.rotation = Quaternion.LookRotation(direction, transform.up);
        }
    }

    private bool IsMoving()
    {
        return direction.magnitude > 0.5;
    }

    public void ChangeMovementDir(Vector3 newDir)
    {
        direction = newDir;
    }
}
