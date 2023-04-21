using UnityEngine;
using FSM;

public class RoomBotController : Controller
{
    #region Params
    public Vector3[] pos;

    public Light light_ { private set; get; }

    //Movement
    [HideInInspector] public int index;
    [HideInInspector] public Quaternion lookRotation;

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

        index = 1;
        base.Start();
    }
}
