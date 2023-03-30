using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/RoomBot/Action/RoomBotBehaviour", fileName = "AcRoomBotBehaviour")]
public class RoomBotBehaviour : RoomBotCollisionBehaviour
{
    public override void ExtraAction(Collider[] colliders, RoomBotController roomBotController)
    {
        if (0 < colliders.Length)
        {
            if (!roomBotController.isCollinding)
            {
                if (!roomBotController.NotActive)
                {
                    roomBotController.NotActive = true;
                    roomBotController.timer = roomBotController.cooldownMax / 8;
                    roomBotController.light_.color = roomBotController.roomBotSO.Color;
                }
                else
                {
                    roomBotController.NotActive = false;
                    roomBotController.cooldown = roomBotController.cooldownMax;
                    roomBotController.light_.enabled = true;
                    roomBotController.light_.color = Color.red;
                }
            }

            roomBotController.isCollinding = true;
        }
        else
            roomBotController.isCollinding = false;
    }
}