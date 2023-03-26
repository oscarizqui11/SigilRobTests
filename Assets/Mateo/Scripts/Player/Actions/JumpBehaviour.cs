using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/JumpBehaviour", fileName = "AcJumpBehaviour")]
public class JumpBehaviour : Action
{
    [SerializeField] private float jumpForce;

    private PlayerController playerController;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
    }

    public override void Act()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //if(!Camera.main.GetComponentInChildren<CameraController>().GetIsFirstPerson())
                playerController._rb.AddForce(playerController.transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
