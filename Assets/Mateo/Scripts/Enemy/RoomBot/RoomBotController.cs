using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBotController : MonoBehaviour
{
    private RoomBotCollisionBehaviour roomBotCollisionBehaviour_;
    private RoomBotMovementBehaviour roomBotMovementBehaviour_;

    private void Start()
    {
        roomBotCollisionBehaviour_ = GetComponent<RoomBotCollisionBehaviour>();
        roomBotMovementBehaviour_ = GetComponent<RoomBotMovementBehaviour>();
    }

    private void Update()
    {
        if (!roomBotCollisionBehaviour_.NotActive_)
            roomBotMovementBehaviour_.Movement();
    }

    private void FixedUpdate()
    {
        roomBotCollisionBehaviour_.Action();
    }
}
