using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateCameraRotationInput", fileName = "EvaluateCameraRotationInput")]
public class EvaluateCameraRotationInput : Action
{
    public float camSensibility;
    private float xRotation;

    private Vector3 movDir;
    private float inputDir;

    float mouseXinput;
    float mouseYinput;

    private PlayerController playerController;

    //public MyVec3Event onChangeDir;

    public GameEvent changeCameraRotation;

    public InputAction lookXAxisAction;
    public InputAction lookYAxisAction;

    public void OnEnable()
    {
        lookXAxisAction.Enable();
        lookYAxisAction.Enable();
    }
    public void OnDisable()
    {
        lookXAxisAction.Disable();
        lookYAxisAction.Disable();
    }

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
    }

    public override void Act(Controller controller)
    {

        mouseXinput = lookXAxisAction.ReadValue<float>();
        mouseYinput = lookYAxisAction.ReadValue<float>();

        float mouseX = mouseXinput * camSensibility * Time.deltaTime;
        xRotation += mouseYinput * camSensibility * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -50, 70);

        Camera.main.transform.eulerAngles = new Vector3(-xRotation, Camera.main.transform.eulerAngles.y + mouseX, 0);
        playerController.transform.Rotate(0, mouseX, 0);


        //changeCameraRotation.Raise(movDir);

    }
}

