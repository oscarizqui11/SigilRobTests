using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class RoomBotController : Controller
{
    public static RoomBotController _roomBotController { get; private set; }

    public Vector3[] pos;
    public bool NotActive_;

    //Events
    [HideInInspector] public bool hasReceivedEvent = true;
    [HideInInspector] public Event receivedEvent;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
