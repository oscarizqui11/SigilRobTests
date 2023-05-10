using UnityEngine;
using FSM;
using SRobEngine.SRobPlayer;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "FSM/Player/Action/DoubleJumpBehaviour", fileName = "AcDoubleJumpBehaviour")]
public class DoubleJumpBehaviour : Action
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float batterySubstraction;

    private PlayerController playerController;

    public InputAction jumpAction;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
        jumpAction.Enable();
    }

    public override void Act(Controller controller)
    {
        if (jumpAction.triggered && playerController.GetJump() && playerController.GetJetpackActive())
        {
            playerController.battery -= batterySubstraction;
            playerController.SetJump(false);
            playerController._rb.AddForce(playerController.transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
