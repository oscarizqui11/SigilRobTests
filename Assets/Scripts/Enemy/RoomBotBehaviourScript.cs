using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBotBehaviourScript : MonoBehaviour
{
    #region Parameters
    [SerializeField] private Vector3[] pos;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;

    private Quaternion lookRotation;
    private Vector3 dir;
    private int index;

    public bool NotActive_ { private get; set; }
    #endregion

    #region Interpolation
    private float totalTime;
    private float factor;
    private float currentTime;

    private bool assignedPoint;

    private Vector3 pointA;
    private Vector3 pointB;
    #endregion

    private void Update()
    {
        Movement();
        Action();
    }

    private void Movement()
    {
        if (!NotActive_)
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

    private void Action()
    {
        
    }
}