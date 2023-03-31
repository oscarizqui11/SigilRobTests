using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateMovemntInputs", fileName = "EvaluateMovemntInputs")]
public class EvaluateMovementInputs : Action
{
    private Vector3 movDir;
    private Vector2 inputDir;

    [SerializeField]
    private float inputChangeDif;

    private PlayerController playerController;

    //public MyVec3Event onChangeDir;

    public GameEvent changeDirection;

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

        if (Mathf.Abs(inputDir.x - nextInputDir.x) > inputChangeDif || Mathf.Abs(inputDir.y - nextInputDir.y) > inputChangeDif)
        {
            inputDir = nextInputDir;

            Vector3 movDirHor = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * inputDir.x;
            Vector3 movDirVer = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * inputDir.y;

            movDir = movDirVer + movDirHor;
        }
        /*if (Mathf.Abs(inputDir.x - Input.GetAxisRaw("Horizontal")) > playerController.inputChangeDif || Mathf.Abs(inputDir.y - Input.GetAxisRaw("Vertical")) > playerController.inputChangeDif)
        {
            inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            Vector3 movDirHor = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * inputDir.x;
            Vector3 movDirVer = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * inputDir.y;

            movDir = movDirVer + movDirHor;
        }*/

        changeDirection.Raise(movDir);
            //onChangeDir.Invoke(movDir);
            //playerController._mb.MoveRB(movDir.normalized * movDir.normalized.magnitude, velocity);
            //playerController.transform.rotation = Quaternion.LookRotation(movDir, playerController.transform.up);
        
    }    
}
