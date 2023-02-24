using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementBehaviour _mb;
    
    private Vector3 movDir;
    private Vector2 inputDir;

    [Range(0,1)]
    [SerializeField] float inputChangeDif;


    private void Start()
    {
        _mb = GetComponent<MovementBehaviour>();
    }

    void FixedUpdate()
    {
        if(Mathf.Abs(inputDir.x - Input.GetAxisRaw("Horizontal")) > inputChangeDif || Mathf.Abs(inputDir.y - Input.GetAxisRaw("Vertical")) > inputChangeDif)
        {
            inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            Vector3 movDirHor = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * inputDir.x;
            Vector3 movDirVer = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * inputDir.y;

            movDir = movDirVer + movDirHor;
        }

        if(movDir.magnitude > 0 + inputChangeDif)
        {
            _mb.MoveRB(movDir.normalized * movDir.normalized.magnitude);
            transform.rotation = Quaternion.LookRotation(movDir, transform.up);
        }
    }
}
