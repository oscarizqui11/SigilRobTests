using UnityEngine;

public class LaserMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    #region Interporlation
    private float totalTime;
    private float factor;
    private float currentTime;

    private bool assignedPoint;

    private Vector3 dir;

    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    #endregion

    public void Movement() 
    {
        if (!assignedPoint)
        {
            float dist = Vector3.Distance(pointA, pointB);

            totalTime = dist / speed;
            assignedPoint = true;

            dir = (pointB - pointA).normalized;
        }

        currentTime += Time.deltaTime;
        factor = currentTime / totalTime;

        Vector3 valueIPos = pointA + (pointB - pointA) * factor;
        transform.position = valueIPos;

        if (currentTime > totalTime)
        {
            currentTime = 0;
            assignedPoint = false;

            var pointC = pointA;
            pointA = pointB;
            pointB = pointC;
        }
    }
}
