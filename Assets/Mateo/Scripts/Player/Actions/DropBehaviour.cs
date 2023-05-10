using UnityEngine;
using SRobEngine.SRobPlayer;

[CreateAssetMenu(menuName = "FSM/Player/Action/DropBehaviour", fileName = "AcDropBehaviour")]
public class DropBehaviour : DragParentBehaviour
{
    public override void Drag(PlayerController playerController)
    {
        playerController.objectDraggable.parent = null;
        playerController.playerState = PlayerState.Grounded;
    }
}
