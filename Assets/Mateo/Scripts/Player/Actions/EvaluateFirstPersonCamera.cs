using UnityEngine;
using FSM;
using UnityEngine.InputSystem;
using SRobEngine.SRobPlayer;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateFirstPersonCamera", fileName = "EvaluateFirstPersonCamera")]
public class EvaluateFirstPersonCamera : Action
{
    private PlayerController playerController;

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

            if(mainCamController.isFirstPerson)
                playerController.playerState = PlayerState.FirstPerson;
            else
                playerController.playerState = PlayerState.Grounded;
        }        
    }
}
