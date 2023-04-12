using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserData : MonoBehaviour
{
    [HideInInspector] public float totalTime;
    [HideInInspector] public float factor;
    [HideInInspector] public float currentTime;

    [HideInInspector] public bool assignedPoint;

    [HideInInspector] public Vector3 dir;

    [HideInInspector] public LineRenderer lr_;

    public Vector3 pointA;
    public Vector3 pointB;
}
