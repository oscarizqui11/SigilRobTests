using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public abstract class RoomBotActionBehaviour : Action
{
    #region Params
    [Header("Collider Parameters")]
    [SerializeField] private Vector3 boxLocation;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask playerMask;

    protected bool isCollinding;

    [Header("Reactivated Parameters")]
    [SerializeField] protected float cooldownMax;
    [SerializeField] protected Color color_;

    protected float cooldown;
    protected float timer;
    #endregion

    private RoomBotController roomBotController;

    public override void Innit(Controller controller)
    {
        cooldown = cooldownMax;

        roomBotController = (RoomBotController)controller;
    }

    public override void Act(Controller controller)
    {
        Collider[] colliders = Physics.OverlapBox(
                                        new Vector3(roomBotController.transform.position.x + boxLocation.x, roomBotController.transform.position.y + boxLocation.y, roomBotController.transform.position.z + boxLocation.z),
                                            new Vector3(roomBotController.transform.localScale.x * boxSize.x, roomBotController.transform.localScale.y * boxSize.y, roomBotController.transform.localScale.z * boxSize.z) / 2,
                                                Quaternion.identity,
                                                    playerMask);

        ExtraAction(colliders, roomBotController);

        if (roomBotController.NotActive_)
        {
            cooldown -= Time.deltaTime;

            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                roomBotController.light_.enabled = !roomBotController.light_.enabled;
                timer = cooldown / 8;
            }

            if (cooldown <= 0)
            {
                roomBotController.NotActive_ = false;
                cooldown = cooldownMax;
                roomBotController.light_.enabled = true;
                roomBotController.light_.color = Color.red;
            }
        }
    }

    public abstract void ExtraAction(Collider[] colliders, RoomBotController roomBotController);
}
