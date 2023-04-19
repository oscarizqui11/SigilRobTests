using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "FSM/Player/Action/MovementBehaviour", fileName = "AcMovementBehaviour")]
public class MovementBehaviour : Action
{
    private PlayerController playerController;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
    }

    public override void Act(Controller controller)
    {
        Transform transform = playerController.transform;

        playerController._mb.MoveRB(playerController.GetDir().normalized * playerController.GetDir().normalized.magnitude);
        transform.rotation = Quaternion.LookRotation(playerController.GetDir(), transform.up);
    }
}
