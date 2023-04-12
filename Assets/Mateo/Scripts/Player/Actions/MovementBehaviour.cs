using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/MovementBehaviour", fileName = "AcMovementBehaviour")]
public class MovementBehaviour : Action
{
    [SerializeField] private float velocity;

    private Vector3 movDir;
    private Vector2 inputDir;

    private PlayerController playerController;

    public override void Act(Controller controller)
    {
        playerController = (PlayerController)controller;

        if (Mathf.Abs(inputDir.x - Input.GetAxisRaw("Horizontal")) > playerController.inputChangeDif || Mathf.Abs(inputDir.y - Input.GetAxisRaw("Vertical")) > playerController.inputChangeDif)
        {
            inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            Vector3 movDirHor = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * inputDir.x;
            Vector3 movDirVer = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * inputDir.y;

            movDir = movDirVer + movDirHor;
        }

        if (movDir.magnitude > 0 + playerController.inputChangeDif)
        {
            MoveRB(movDir.normalized * movDir.normalized.magnitude);
            playerController.transform.rotation = Quaternion.LookRotation(movDir, playerController.transform.up);
        }
    }

    public void MoveRB(Vector3 dir)
    {
        if (!WillCollide(dir))
            playerController._rb.MovePosition(playerController.transform.position + velocity * Time.fixedDeltaTime * dir);
    }

    private bool WillCollide(Vector3 dir)
    {
        return false;
    }
}
