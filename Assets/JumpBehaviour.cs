    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    Rigidbody _body;

    bool desiredJump;
    float verticalVelocity;
    bool onGround;
    
    [SerializeField, Range(0f, 10f)]
    float jumpHeight = 2f;
    [SerializeField, Range(0, 3)]
    int maxAirJumps = 0;
    int jumpPhase;

    void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        desiredJump |= Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        UpdateState();

        if (desiredJump)
        {
            desiredJump = false;
            Jump();
        }
        _body.velocity = new Vector3(0, verticalVelocity, 0);
        onGround = false;
    }

    void UpdateState()
    {
        verticalVelocity = _body.velocity.y;
        if(onGround)
        {
            jumpPhase = 0;
        }
    }

    void Jump()
    {
        if (onGround || jumpPhase < maxAirJumps)
        {
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            if(verticalVelocity > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - verticalVelocity, 0f);
            }
            verticalVelocity += jumpSpeed;
        }
    }

    void EvaluateCollision(Collision collision)
    {
        for(int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }
}
