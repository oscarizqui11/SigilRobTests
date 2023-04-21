using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "FSM/Player/Action/DashBehaviour", fileName = "AcDashBehaviour")]
public class DashBehaviour : Action
{
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCd;
    [SerializeField] private float dashDuration;
    [SerializeField] private float batterySubstraction;

    private float DashCdTimer;

    private PlayerController playerController;

    public InputAction dashAction;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
        dashAction.Enable();
    }

    public override void Act(Controller controller)
    {
        if (DashCdTimer > 0)
            DashCdTimer -= Time.deltaTime;

        if (dashAction.triggered && playerController.GetJetpackActive())
        {
            if (DashCdTimer > 0)
                return;
            else
                DashCdTimer = dashCd;

            Vector3 forceToApply = playerController.transform.forward * dashForce;

            playerController._rb.AddForce(forceToApply, ForceMode.Impulse);
            playerController.battery -= batterySubstraction;
        } 
    }
}
