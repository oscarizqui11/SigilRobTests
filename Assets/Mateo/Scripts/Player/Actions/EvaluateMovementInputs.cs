using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateMovementInputs", fileName = "AcEvaluateMovementInputs")]
public class EvaluateMovementInputs : Action
{
    private Vector2 inputDir;

    [SerializeField] private float inputChangeDif;

    private PlayerController playerController;

    public InputAction moveAction;

    public void OnEnable()
    {
        moveAction.Enable();
    }
    public void OnDisable()
    {
        moveAction.Disable();
    }

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
    }

    public override void Act(Controller controller)
    {
        Vector2 nextInputDir = moveAction.ReadValue<Vector2>();
        Transform transform = playerController.transform;

        if (Mathf.Abs(inputDir.x - nextInputDir.x) > inputChangeDif || Mathf.Abs(inputDir.y - nextInputDir.y) > inputChangeDif)
        {
            inputDir = nextInputDir;

            Vector3 movDirHor = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * inputDir.x;
            Vector3 movDirVer = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * inputDir.y;

            playerController.SetDir(movDirVer + movDirHor);
        }

        if (playerController.GetDir() != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(playerController.GetDir(), transform.up);
    }    
}
