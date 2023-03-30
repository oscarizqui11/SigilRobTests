using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

using SRobEngine.SRobPlayer;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateFirstPersonCamera", fileName = "EvaluateFirstPersonCamera")]
public class EvaluateFirstPersonCamera : Action
{
    private PlayerController playerController;
    public GameEvent changeDirection;

    //public Camera mainCamera;

    public InputAction firstPersonAction;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
        firstPersonAction.Enable();
    }

    public override void Act(Controller controller)
    {
        if (firstPersonAction.triggered)
        {
            CameraController mainCamController = Camera.main.GetComponent<CameraController>();
            mainCamController.ToggleFirstPerson();

            if(mainCamController.GetIsFirstPerson())
            {
                playerController.playerState = PlayerState.FirstPerson;
                changeDirection.Raise(Vector3.zero);
            }
            else
            {
                playerController.playerState = PlayerState.Grounded;
            }

        }        
    }
}
