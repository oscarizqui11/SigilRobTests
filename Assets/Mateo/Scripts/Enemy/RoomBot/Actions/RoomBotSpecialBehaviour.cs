using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/RoomBot/Action/RoomBotSpecialBehaviour", fileName = "AcRoomBotSpecialBehaviour")]
public class RoomBotSpecialBehaviour : RoomBotCollisionBehaviour
{
    protected float bounce => roomBotSO.Bounce;

    public override void ExtraAction(Collider[] colliders, RoomBotController roomBotController)
    {
        if (!roomBotController.isCollinding)
        {
            if (!roomBotController.NotActive)
            {
                roomBotController.NotActive = true;
                roomBotController.light_.color = color;
            }

            colliders[0].gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * bounce;
        }

        roomBotController.isCollinding = true;
    }
}
