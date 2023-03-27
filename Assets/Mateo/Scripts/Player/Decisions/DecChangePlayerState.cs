using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using SRobEngine.SRobPlayer;

[CreateAssetMenu(menuName = "FSM/Player/Decision/DecChangePlayerState", fileName = "DecChangePlayerState")]
public class DecChangePlayerState : Decision
{
    [SerializeField] private PlayerState playerState;

    public override bool Decide(Controller controller)
    {
        PlayerController playerController = (PlayerController)controller;

        Debug.Log(playerController.playerState + "vs" + playerState);

        if (((int)playerController.playerState) == ((int)playerState))
            return true;
        else
            return false;
    }
}
