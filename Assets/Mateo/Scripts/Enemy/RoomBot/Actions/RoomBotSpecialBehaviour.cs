using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/RoomBot/Action/RoomBotSpecialBehaviour", fileName = "AcRoomBotSpecialBehaviour")]
public class RoomBotSpecialBehaviour : RoomBotCollisionBehaviour
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
                    roomBotController.light_.color = roomBotController.roomBotSO.Color;
                }

                colliders[0].gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * roomBotController.roomBotSO.Bounce;
            }

            roomBotController.isCollinding = true;
        }
        else
            roomBotController.isCollinding = false;
    }
}
