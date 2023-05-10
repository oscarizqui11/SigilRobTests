using UnityEngine;
using FSM;

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
        playerController._mb.MoveRB(playerController.GetDir().normalized);
    }
}
