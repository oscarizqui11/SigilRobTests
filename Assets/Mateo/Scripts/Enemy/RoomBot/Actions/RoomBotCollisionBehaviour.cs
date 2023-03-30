using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public abstract class RoomBotCollisionBehaviour : Action
{
    public override void Innit(Controller controller)
    {
        
    }

    public abstract void ExtraAction(Collider[] colliders, RoomBotController roomBotController);

    public override void Act(Controller controller)
    {
        RoomBotController roomBotController = (RoomBotController)controller;
        Transform transform = roomBotController.transform;
        RoomBotScriptableObject roomBotSO = roomBotController.roomBotSO;

        Vector3 boxLocation = roomBotSO.BoxLoc;
        Vector3 boxSize = roomBotSO.BoxSize;

        Collider[] colliders = Physics.OverlapBox(
                                        new Vector3(transform.position.x + boxLocation.x, transform.position.y + boxLocation.y, transform.position.z + boxLocation.z),
                                            new Vector3(transform.localScale.x * boxSize.x, transform.localScale.y * boxSize.y, transform.localScale.z * boxSize.z) / 2,
                                                Quaternion.identity,
                                                    roomBotSO.PlayerMask);

        ExtraAction(colliders, roomBotController);

        if (roomBotController.NotActive)
        {
            roomBotController.cooldown -= Time.fixedDeltaTime;

            if (roomBotController.timer > 0)
                roomBotController.timer -= Time.fixedDeltaTime;
            else
            {
                roomBotController.light_.enabled = !roomBotController.light_.enabled;
                roomBotController.timer = roomBotController.cooldown / 8;
            }

            if (roomBotController.cooldown <= 0)
            {
                roomBotController.NotActive = false;
                roomBotController.cooldown = roomBotController.cooldownMax;
                roomBotController.light_.enabled = true;
                roomBotController.light_.color = Color.red;
            }
        }
    }
}
