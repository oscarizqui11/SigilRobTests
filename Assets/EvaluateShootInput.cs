using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

using SRobEngine.SRobPlayer;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateShootInput", fileName = "EvaluateShootInput")]
public class EvaluateShootInput : Action
{
    public bool isRanged;

    public InputAction shootingAction;

    public override void Innit(Controller controller)
    {
        shootingAction.Enable();
    }

    public override void Act(Controller controller)
    {
        if (shootingAction.triggered)
        {
            controller.GetComponent<ShootingBhFSM>().Shoot(isRanged);
        }
    }
}
