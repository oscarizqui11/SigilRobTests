using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementBehaviour _mb;

    private void Start()
    {
        _mb = GetComponent<MovementBehaviour>();   
    }

    void FixedUpdate()
    {
        Vector3 movDirVer = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * Input.GetAxisRaw("Vertical");
        Vector3 movDirHor = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * Input.GetAxisRaw("Horizontal");

        Vector3 movDir = movDirVer + movDirHor;

        if(movDir.magnitude > 0)
        {
            _mb.MoveRB(movDir.normalized);
            transform.rotation = Quaternion.LookRotation(movDir, transform.up);
        }
    }
}
