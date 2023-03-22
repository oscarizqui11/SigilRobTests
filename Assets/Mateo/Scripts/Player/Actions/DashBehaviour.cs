using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/DashBehaviour", fileName = "AcDashBehaviour")]
public class DashBehaviour : Action
{
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCd;
    [SerializeField] private float dashDuration;

    private float DashCdTimer;

    private PlayerController playerController;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
    }

    public override void Act(Controller controller)
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (DashCdTimer > 0)
                return;
            else
                DashCdTimer = dashCd;

            Vector3 forceToApply = playerController.transform.forward * dashForce;

            playerController._rb.AddForce(forceToApply, ForceMode.Impulse);
        }

        if (DashCdTimer > 0)
            DashCdTimer -= Time.deltaTime;
    }
}
