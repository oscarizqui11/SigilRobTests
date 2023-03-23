using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Roombot/Action/RoomBotMovementBehaviour", fileName = "AcRoomBotMovementBehaviour")]
public class RoomBotMovementBehaviour : Action
{
    #region Params
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;

    private Quaternion lookRotation;
    private Vector3 dir;
    private int index;
    #endregion

    #region Interpolation
    private float totalTime;
    private float factor;
    private float currentTime;

    private bool assignedPoint;

    private Vector3 pointA;
    private Vector3 pointB;
    #endregion

    private RoomBotController roomBotController;

    public override void Innit(Controller controller)
    {
        roomBotController = (RoomBotController)controller;
    }

    public override void Act(Controller controller)
    {
        if (!roomBotController.NotActive_)
        {
            if (!assignedPoint)
            {
                pointA = roomBotController.transform.position;
                pointB = roomBotController.pos[index];

                float dist = Vector3.Distance(pointA, pointB);

                totalTime = dist / speed;
                assignedPoint = true;

                dir = (pointB - pointA).normalized;
                lookRotation = Quaternion.LookRotation(dir);
            }

            currentTime += Time.deltaTime;
            factor = currentTime / totalTime;

            Vector3 valueIPos = pointA + (pointB - pointA) * factor;
            roomBotController.transform.position = valueIPos;
            roomBotController.transform.rotation = Quaternion.Slerp(roomBotController.transform.rotation, lookRotation, Time.deltaTime * speedRotation);

            if (currentTime > totalTime)
            {
                currentTime = 0;
                assignedPoint = false;

                if (index < roomBotController.pos.Length - 1)
                    index++;
                else
                    index = 0;
            }
        }
    }
}
