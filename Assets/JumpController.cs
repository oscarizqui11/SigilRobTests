using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody _rb;

    private bool grounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        grounded = true;
    }

    void Update()
    {
        if(grounded && Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
        {
            grounded = false;
        }
    }
}
