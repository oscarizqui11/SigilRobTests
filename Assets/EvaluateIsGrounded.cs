using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using SRobEngine;
using SRobEngine.SRobPlayer;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateIsGrounded", fileName = "EvaluateIsGrounded")]
public class EvaluateIsGrounded : Action
{
    private PlayerController playerController;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
    }

    public override void Act(Controller controller)
    {
        if(playerController.GetComponent<DetectCollisionScript>().GetIsColliding())
        {
            playerController.playerState = PlayerState.Grounded;
        }
        else
        {
            playerController.playerState = PlayerState.Airborne;
        }
    }
}
