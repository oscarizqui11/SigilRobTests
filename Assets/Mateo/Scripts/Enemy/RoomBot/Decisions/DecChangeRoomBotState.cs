using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Roombot/Decision/DecChangeRoomBotState", fileName = "DecChangeRoomBotState")]
public class DecChangeRoomBotState : Decision
{
    [SerializeField] private bool StateActive;

    public override bool Decide(Controller controller)
    {
        RoomBotController roomBotController = (RoomBotController)controller;

        if (roomBotController.NotActive_ != StateActive)
            return true;
        else
            return false;
    }
}
