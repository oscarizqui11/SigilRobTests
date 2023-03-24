using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateMovemntInputs", fileName = "EvaluateMovemntInputs")]
public class EvaluateMovementInputs : Action
{
    private Vector3 movDir;
    private Vector2 inputDir;

    private PlayerController playerController;

    public MyVec3Event onChangeDir;

    public GameEvent changeDirrection;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
    }

    public override void Act(Controller controller)
    {
        if (Mathf.Abs(inputDir.x - Input.GetAxisRaw("Horizontal")) > playerController.inputChangeDif || Mathf.Abs(inputDir.y - Input.GetAxisRaw("Vertical")) > playerController.inputChangeDif)
        {
            inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            Vector3 movDirHor = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * inputDir.x;
            Vector3 movDirVer = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * inputDir.y;

            movDir = movDirVer + movDirHor;
        }

        if (movDir.magnitude > 0 + playerController.inputChangeDif)
        {
            changeDirrection.Raise(movDir);
            //onChangeDir.Invoke(movDir);
            //playerController._mb.MoveRB(movDir.normalized * movDir.normalized.magnitude, velocity);
            //playerController.transform.rotation = Quaternion.LookRotation(movDir, playerController.transform.up);
        }
    }
}
