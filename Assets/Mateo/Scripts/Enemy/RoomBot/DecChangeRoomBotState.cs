using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/RoomBot/Decision/DecChangeRoomBotState", fileName = "DecChangeRoomBotState")]
public class DecChangeRoomBotState : Decision
{
    [SerializeField] private bool NotActive;

    public override bool Decide(Controller controller)
    {
        RoomBotController roomBotController = (RoomBotController)controller;

        if (roomBotController.NotActive == NotActive)
            return true;
        else
            return false;
    }
}
