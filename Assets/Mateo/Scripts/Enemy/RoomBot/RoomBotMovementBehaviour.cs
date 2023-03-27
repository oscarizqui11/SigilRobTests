using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBotMovementBehaviour : MonoBehaviour
{
    #region Params
    [Header("Movement Parameters")]
    [SerializeField] private Vector3[] pos;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;

    private Quaternion lookRotation;
    private Vector3 dir;
    private int index = 1;
    #endregion

    #region Interpolation
    private float totalTime;
    private float factor;
    private float currentTime;

    private bool assignedPoint;

    private Vector3 pointA;
    private Vector3 pointB;
    #endregion

    public void Movement()
    {
        if (!assignedPoint)
        {
            pointA = transform.position;
            pointB = pos[index];

            float dist = Vector3.Distance(pointA, pointB);

            totalTime = dist / speed;
            assignedPoint = true;

            dir = (pointB - pointA).normalized;
            lookRotation = Quaternion.LookRotation(dir);
        }

        currentTime += Time.deltaTime;
        factor = currentTime / totalTime;

        Vector3 valueIPos = pointA + (pointB - pointA) * factor;
        transform.position = valueIPos;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speedRotation);

        if (currentTime > totalTime)
        {
            currentTime = 0;
            assignedPoint = false;

            if (index < pos.Length - 1)
                index++;
            else
                index = 0;
        }
    }
}
