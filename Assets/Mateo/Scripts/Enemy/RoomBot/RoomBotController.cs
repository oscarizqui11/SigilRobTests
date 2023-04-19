using UnityEngine;
using FSM;

public class RoomBotController : Controller
{
    #region Params
    public Vector3[] pos;

    public Light light_ { private set; get; }

    //Movement
    public int index;
    public Quaternion lookRotation;

    //Collision
    public bool isCollinding;

    public float cooldown;
    public float timer;

    public bool NotActive;
    #endregion

    #region Interpolation
    public float totalTime;
    public float currentTime;

    public bool assignedPoint;

    public Vector3 pointA;
    public Vector3 pointB;
    #endregion

    public override void Start()
    {
        light_ = GetComponentInChildren<Light>();

        index = 1;
        base.Start();
    }
}
