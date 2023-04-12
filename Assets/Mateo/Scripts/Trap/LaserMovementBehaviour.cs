using UnityEngine;

public class LaserMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    public void Movement(LaserData laserData)
    {
        if (!laserData.assignedPoint)
        {
            float dist = Vector3.Distance(laserData.pointA, laserData.pointB);

            laserData.totalTime = dist / speed;
            laserData.assignedPoint = true;

            laserData.dir = (laserData.pointB - laserData.pointA).normalized;
        }

        laserData.currentTime += Time.deltaTime;
        laserData.factor = laserData.currentTime / laserData.totalTime;

        Vector3 valueIPos = laserData.pointA + (laserData.pointB - laserData.pointA) * laserData.factor;
        laserData.transform.position = valueIPos;

        if (laserData.currentTime > laserData.totalTime)
        {
            laserData.currentTime = 0;
            laserData.assignedPoint = false;

            var pointC = laserData.pointA;
            laserData.pointA = laserData.pointB;
            laserData.pointB = pointC;
        }
    }
}
