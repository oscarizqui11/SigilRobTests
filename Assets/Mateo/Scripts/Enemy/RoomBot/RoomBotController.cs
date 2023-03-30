using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class RoomBotController : Controller
{
    #region Params
    [Header("Movement Parameters")]
    public Vector3[] pos;
    public RoomBotScriptableObject roomBotSO;

    [HideInInspector] public Rigidbody rb_;
    [HideInInspector] public Light light_;

    [HideInInspector] public Quaternion lookRotation;
    [HideInInspector] public Vector3 dir;
    [HideInInspector] public int index = 1;

    [HideInInspector] public bool isCollinding;

    public float cooldownMax;

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
        rb_ = GetComponent<Rigidbody>();
        light_ = GetComponentInChildren<Light>();

        base.Start();
    }
}
