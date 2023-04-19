using UnityEngine;
using FSM;

public abstract class RoomBotCollisionBehaviour : Action
{
    [SerializeField] protected RoomBotScriptableObject roomBotSO;

    private Vector3 boxLocation => roomBotSO.BoxLoc;
    private Vector3 boxSize => roomBotSO.BoxSize;

    private LayerMask playerMask => roomBotSO.PlayerMask;
    protected Color color => roomBotSO.Color;

    protected float cooldownMax => roomBotSO.CDMax;

    public abstract void ExtraAction(Collider[] colliders, RoomBotController roomBotController);

    public override void Innit(Controller controller)
    {
    }

    public override void Act(Controller controller)
    {
        RoomBotController roomBotController = (RoomBotController)controller;
        Transform transform = roomBotController.transform;

        Collider[] colliders = Physics.OverlapBox(transform.position + boxLocation, (transform.localScale + boxSize) / 6, Quaternion.identity, playerMask, QueryTriggerInteraction.Ignore);
        
        if (0 < colliders.Length)
            ExtraAction(colliders, roomBotController);
        else
            roomBotController.isCollinding = false;

        if (roomBotController.NotActive)
        {
            roomBotController.cooldown -= Time.fixedDeltaTime;

            if (roomBotController.timer < 0)
            {
                roomBotController.light_.enabled = !roomBotController.light_.enabled;
                roomBotController.timer = roomBotController.cooldown / 8;
            }
            else
                roomBotController.timer -= Time.fixedDeltaTime;

            if (roomBotController.cooldown <= 0)
            {
                roomBotController.NotActive = false;
                roomBotController.cooldown = cooldownMax;
                roomBotController.light_.enabled = true;
                roomBotController.light_.color = Color.red;
            }
        }
    }
}
