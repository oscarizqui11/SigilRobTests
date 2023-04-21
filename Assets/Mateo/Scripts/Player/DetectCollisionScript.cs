using UnityEngine;
using SRobEngine.SRobPlayer;

public class DetectCollisionScript : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    [Tooltip("If the collider is a capsule, how much radius is added to the bottom of the collider to detect the collision with the ground.")]
    float stepHeight;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint point in collision.contacts)
            if (point.point.y <= StepPointY())
            {
                playerController.playerState = PlayerState.Grounded;
                playerController.SetJump(false);
            }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (playerController.transform.position.y + playerController._capscol.center.y - playerController._capscol.height / 2 + playerController._capscol.radius * stepHeight - collision.collider.bounds.ClosestPoint(playerController.transform.position + playerController._capscol.center - new Vector3(0, playerController._capscol.height / 2 + playerController._capscol.radius * stepHeight, 0)).y > 0.05f)
            playerController.playerState = PlayerState.Airborne;
    }

    private float StepPointY()
    {
        return playerController.transform.position.y + playerController._capscol.center.y - playerController._capscol.height / 2 + playerController._capscol.radius * stepHeight;
    }
}
