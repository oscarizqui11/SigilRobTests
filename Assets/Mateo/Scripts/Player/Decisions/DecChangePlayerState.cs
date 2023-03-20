using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decision/DecChangePlayerState", fileName = "DecChangePlayerState")]
public class DecChangePlayerState : Decision
{
    public enum PlayerState
    {
        Grounded,
        Airborne,
        Ramming,
        Shooting,
        Holding,
        Healing
    };
    [SerializeField] private PlayerState playerState;

    public override bool Decide(Controller controller)
    {
        PlayerController playerController = (PlayerController)controller;

        if (((int)playerController.playerState) == ((int)playerState))
            return true;
        else
            return false;
    }
}
