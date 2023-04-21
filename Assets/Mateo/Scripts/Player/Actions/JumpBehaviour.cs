using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

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
        if(jumpAction.triggered && !playerController.GetJump())
        {
            playerController.SetJump(true);
            playerController._rb.AddForce(playerController.transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
