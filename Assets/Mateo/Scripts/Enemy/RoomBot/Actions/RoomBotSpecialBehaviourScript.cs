using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Roombot/Action/RoomBotSpecialBehaviourScript", fileName = "AcRoomBotSpecialBehaviourScript")]
public class RoomBotSpecialBehaviourScript : RoomBotActionBehaviour
{
    [SerializeField] private float bounce;

    public override void ExtraAction(Collider[] colliders, RoomBotController roomBotController)
    {
        if (0 < colliders.Length)
        {
            if (!isCollinding)
            {
                if (!roomBotController.NotActive_)
                {
                    roomBotController.NotActive_ = true;
                    light_.color = color_;
                }

                colliders[0].gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * bounce;
            }

            isCollinding = true;
        }
        else
            isCollinding = false;
    }
}
