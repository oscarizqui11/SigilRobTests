using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/RoomBot/Action/RoomBotBehaviour", fileName = "AcRoomBotBehaviour")]
public class RoomBotBehaviour : RoomBotCollisionBehaviour
{
    public override void ExtraAction(Collider[] colliders, RoomBotController roomBotController)
    {
        if (!roomBotController.isCollinding)
        {
            if (!roomBotController.NotActive)
            {
                roomBotController.NotActive = true;
                roomBotController.timer = cooldownMax / 8;
                roomBotController.light_.color = color;
            }
            else
            {
                roomBotController.NotActive = false;
                roomBotController.cooldown = cooldownMax;
                roomBotController.light_.enabled = true;
                roomBotController.light_.color = Color.red;
            }
        }

        roomBotController.isCollinding = true;
    }
}