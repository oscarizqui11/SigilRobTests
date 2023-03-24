using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/DoubleJumpBehaviour", fileName = "AcDoubleJumpBehaviour")]
public class DoubleJumpBehaviour : Action
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float batterySubstraction;

    private bool DoubleJumpUsed = false;

    private PlayerController playerController;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
    }

    public override void Act(Controller controller)
    {
        if (playerController.playerState == PlayerController.PlayerState.Grounded)
            DoubleJumpUsed = false;

        if (Input.GetButtonDown("Jump") && !DoubleJumpUsed)
        {
            playerController._rb.AddForce(playerController.transform.up * jumpForce, ForceMode.Impulse);
            DoubleJumpUsed = true;
            playerController.battery -= batterySubstraction;
        }
    }
}
