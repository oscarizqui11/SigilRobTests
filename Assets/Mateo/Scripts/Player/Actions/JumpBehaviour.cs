using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using UnityEngine.InputSystem;
using SRobEngine.SRobPlayer;
using SRobEngine;

[CreateAssetMenu(menuName = "FSM/Player/Action/JumpBehaviour", fileName = "AcJumpBehaviour")]
public class JumpBehaviour : Action
{
    [SerializeField] private float jumpForce;

    private PlayerController playerController;

    public InputAction jumpAction;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
        jumpAction.Enable();
    }

    public override void Act(Controller controller)
    {

        //if (Input.GetButtonDown("Jump"))
        if(jumpAction.triggered)
        {
            //if(!Camera.main.GetComponentInChildren<CameraController>().GetIsFirstPerson())
            playerController._rb.AddForce(playerController.transform.up * jumpForce, ForceMode.Impulse);
            playerController.playerState = PlayerState.Airborne;
        }
    }
}
