using FSM;
using UnityEngine.InputSystem;

public abstract class DragParentBehaviour : Action
{
    private PlayerController playerController;

    public InputAction dragAction;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
        dragAction.Enable();
    }

    public override void Act(Controller controller)
    {
        if (dragAction.triggered)
            Drag(playerController);
    }

    public abstract void Drag(PlayerController playerController);
}
