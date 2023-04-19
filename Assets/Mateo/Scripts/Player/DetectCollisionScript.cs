using UnityEngine;
using SRobEngine.SRobPlayer;

public class DetectCollisionScript : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    [Tooltip("If the collider is a capsule, how much radius is added to the bottom of the collider to detect the collision with the ground.")]
    float stepHeight;

    private PlayerController playerController;
    private JetpackScript jetpackScript;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        jetpackScript = GetComponent<JetpackScript>();
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint point in collision.contacts)
            if (point.point.y <= StepPointY())
            {
                playerController.playerState = PlayerState.Grounded;
                jetpackScript.SetDoubleJump(false);
            }
    }

    private float StepPointY()
    {
        return playerController.transform.position.y + playerController._capscol.center.y - playerController._capscol.height / 2 + playerController._capscol.radius * stepHeight;
    }
}
