using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody _rb;

    public bool Grounded { get { return grounded; } private set { grounded = value; } }
    private bool grounded;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        grounded = true;
    }

    void Update()
    {
        if(grounded && Input.GetButtonDown("Jump"))
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        Collider[] other = Physics.OverlapBox(gameObject.transform.position, transform.localScale, Quaternion.identity, enemyLayer, QueryTriggerInteraction.Collide);

        int i = 0;

        while (i < other.Length)
        {
            if (other[i].gameObject.layer == enemyLayer)
                other[i].GetComponent<RoomBotBehaviourScript>().NotActive_ = true;

            i++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == groundLayer)
            grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
            grounded = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == enemyLayer)
            grounded = false;
    }
}
