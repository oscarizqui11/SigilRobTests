using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Roombot/Action/RoomBotBehaviourScript", fileName = "AcRoomBotBehaviourScript")]
public class RoomBotBehaviourScript : RoomBotActionBehaviour
{
    public override void ExtraAction(Collider[] colliders, RoomBotController roomBotController)
    {
        if (0 < colliders.Length)
        {
            if (!isCollinding)
            {
                if (!roomBotController.NotActive_)
                {
                    roomBotController.NotActive_ = true;
                    timer = cooldownMax / 8;
                    roomBotController.light_.color = color_;
                }
                else
                {
                    roomBotController.NotActive_ = false;
                    cooldown = cooldownMax;
                    roomBotController.light_.enabled = true;
                    roomBotController.light_.color = Color.red;
                }
            }

            isCollinding = true;
        }
        else
            isCollinding = false;
    }
}