using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class RoomBotController : Controller
{
    #region Params
    public Vector3[] pos;

    [HideInInspector] public Light light_ { private set; get; }

    //Movement
    [HideInInspector] public Quaternion lookRotation;
    [HideInInspector] public Vector3 dir;
    [HideInInspector] public int index = 1;

    //Collision
    [HideInInspector] public bool isCollinding;

    [HideInInspector] public float cooldown;
    [HideInInspector] public float timer;

    [HideInInspector] public bool NotActive;
    #endregion

    #region Interpolation
    [HideInInspector] public float totalTime;
    [HideInInspector] public float currentTime;

    [HideInInspector] public bool assignedPoint;

    [HideInInspector] public Vector3 pointA;
    [HideInInspector] public Vector3 pointB;
    #endregion

    public override void Start()
    {
        light_ = GetComponentInChildren<Light>();

        base.Start();
    }
}
