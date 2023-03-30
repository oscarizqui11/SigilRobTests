using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/RoomBot/Action/RoomBotMovementBehaviour", fileName = "AcRoomBotMovementBehaviour")]
public class RoomBotMovementBehaviour : Action
{
    public override void Innit(Controller controller)
    {

    }

    public override void Act(Controller controller)
    {
        #region Params
        RoomBotController roomBotController = (RoomBotController)controller;
        Transform transform = roomBotController.transform;
        RoomBotScriptableObject roomBotSO = roomBotController.roomBotSO;

        float speed = roomBotSO.Speed;
        float speedRotation = roomBotSO.SpeedRot;
        #endregion

        if (!roomBotController.assignedPoint)
        {
            roomBotController.pointA = transform.position;
            roomBotController.pointB = roomBotController.pos[roomBotController.index];

            float dist = Vector3.Distance(roomBotController.pointA, roomBotController.pointB);

            roomBotController.totalTime = dist / speed;
            roomBotController.assignedPoint = true;

            roomBotController.dir = (roomBotController.pointB - roomBotController.pointA).normalized;
            roomBotController.lookRotation = Quaternion.LookRotation(roomBotController.dir);
        }

        roomBotController.currentTime += Time.deltaTime;
        float factor = roomBotController.currentTime / roomBotController.totalTime;

        Vector3 valueIPos = roomBotController.pointA + (roomBotController.pointB - roomBotController.pointA) * factor;
        transform.position = valueIPos;
        transform.rotation = Quaternion.Slerp(transform.rotation, roomBotController.lookRotation, Time.deltaTime * speedRotation);

        if (roomBotController.currentTime > roomBotController.totalTime)
        {
            roomBotController.currentTime = 0;
            roomBotController.assignedPoint = false;

            if (roomBotController.index < roomBotController.pos.Length - 1)
                roomBotController.index++;
            else
                roomBotController.index = 0;
        }
    }
}
