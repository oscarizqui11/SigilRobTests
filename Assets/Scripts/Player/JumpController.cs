using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody _rb;

    public bool Grounded { get { return grounded; } private set { grounded = value; } }
    private bool grounded;

    [SerializeField] private string groundLayer;
    [SerializeField] private string enemyLayer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        grounded = true;
    }

    void Update()
    {
        if(grounded && Input.GetButtonDown("Jump"))
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == groundLayer)
            grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == groundLayer)
            grounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == enemyLayer)
        {
            grounded = true;
            other.GetComponent<RoomBotMovementScript>().NotActive_ = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == groundLayer)
            grounded = false;
    }
}
