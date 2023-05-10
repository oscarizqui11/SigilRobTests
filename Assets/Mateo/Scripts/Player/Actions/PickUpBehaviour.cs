using UnityEngine;
using SRobEngine.SRobPlayer;

[CreateAssetMenu(menuName = "FSM/Player/Action/PickUpBehaviour", fileName = "AcPickUpBehaviour")]
public class PickUpBehaviour : DragParentBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask layerMask;

    public override void Drag(PlayerController playerController)
    {
        Transform transform = playerController.transform;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            GameObject go = hit.transform.gameObject;

            if (go.layer == layerMask)
            {
                playerController.playerState = PlayerState.Holding;
                playerController.objectDraggable = go.transform;

                go.transform.SetParent(transform);
            }
        } 
    }
}
