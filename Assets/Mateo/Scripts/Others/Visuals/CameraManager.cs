using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager _cameraManager { get; private set; }

    #region Params
    [SerializeField] private Vector3 distance;

    private bool assignedPos;
    private bool assignedRot;

    private Vector3 pointA;
    private Vector3 pointB;

    private Vector3 angleA;
    private Vector3 angleB;

    private float factorA;
    private float factorB;

    private float totalTimeA;
    private float totalTimeB;

    private float currentTimePos;
    private float currentTimeRot;
    #endregion

    private void Awake()
    {
        if (_cameraManager == null)
            _cameraManager = this;
        else Destroy(this);
    }

    public bool MoveCameraPos(Vector3 pos, float speedPos)
    {
        if (!assignedPos)
        {
            pointA = transform.position;
            pointB = pos + distance;

            totalTimeA = Vector3.Distance(pointA, pointB) / speedPos;
            assignedPos = true;
        }

        factorA = currentTimePos / totalTimeA;
        currentTimePos += Time.deltaTime;

        Vector3 valueIPos = pointA + (pointB - pointA) * factorA;
        transform.position = valueIPos;

        if (currentTimePos > totalTimeA)
        {
            currentTimePos = 0;
            assignedPos = false;
        }

        return assignedPos;
    }

    public bool MoveCameraRot(Vector3 ang, float speedRot)
    {
        if (!assignedRot)
        {
            angleA = transform.eulerAngles;
            angleB = transform.eulerAngles + ang;

            totalTimeB = Vector3.Distance(angleA, angleB) / speedRot;
            assignedRot = true;
        }

        factorB = currentTimeRot / totalTimeB;
        currentTimeRot += Time.deltaTime;

        Vector3 valueIRot = angleA + (angleB - angleA) * factorB;
        transform.rotation = Quaternion.Euler(valueIRot);

        if (currentTimeRot > totalTimeB)
        {
            currentTimeRot = 0;
            assignedRot = false;
        }

        return assignedRot;
    }

    public bool MoveCamera(Vector3 pos, Vector3 ang, float speedPos, float speedRot)
    { 
        return MoveCameraPos(pos, speedPos) || MoveCameraRot(ang, speedRot);
    }
}
