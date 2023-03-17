using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackBehaviourScript : MonoBehaviour
{
    #region Parameters
    [Header("Dashing")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCd;
    [SerializeField] private float dashDuration;

    private bool DashUsed;
    private float DashCdTimer;

    [Header("Double Jump")]
    [SerializeField] private float jumpForce;

    private bool DoubleJumpUsed;

    private Rigidbody rb_;
    private JumpController jumpController_;
    #endregion

    private void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        jumpController_ = GetComponent<JumpController>();
    }

    private void Update()
    {
        DoubleJump();
        Dash();
    }

    private void DoubleJump()
    {
        if (DoubleJumpUsed)
            DoubleJumpUsed = !jumpController_.Grounded;

        if (!jumpController_.Grounded && Input.GetButtonDown("Jump") && !DoubleJumpUsed)
        {
            rb_.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            DoubleJumpUsed = true;
        }
    }

    private void Dash()
    {
        if (DashCdTimer > 0)
            return;
        else
            DashCdTimer = dashCd;

        if (Input.GetMouseButton(1) && !DashUsed)
        {

        }
    }
    private Vector3 GetDirection(Transform forwardT)
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3();
        direction = forwardT.forward * verticalInput + forwardT.right * horizontalInput;

        if (verticalInput == 0 && horizontalInput == 0)
            direction = forwardT.forward;

        return direction.normalized;
    }
}
