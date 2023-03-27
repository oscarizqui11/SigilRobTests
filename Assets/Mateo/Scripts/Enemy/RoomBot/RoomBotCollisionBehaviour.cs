using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoomBotCollisionBehaviour : MonoBehaviour
{
    #region Parameters
    [Header("Collider Parameters")]
    [SerializeField] private Vector3 boxLocation;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask playerMask;

    private Rigidbody rb_;
    protected bool isCollinding;

    [Header("Reactivated Parameters")]
    [SerializeField] protected float cooldownMax;
    [SerializeField] protected Color color_;

    protected Light light_;
    protected float cooldown;
    protected float timer;

    public bool NotActive_ { protected set; get; }
    #endregion

    private void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        light_ = GetComponentInChildren<Light>();
        cooldown = cooldownMax;
    }

    public abstract void ExtraAction(Collider[] colliders);

    public void Action()
    {
        Collider[] colliders = Physics.OverlapBox(
                                        new Vector3(transform.position.x + boxLocation.x, transform.position.y + boxLocation.y, transform.position.z + boxLocation.z),
                                            new Vector3(transform.localScale.x * boxSize.x, transform.localScale.y * boxSize.y, transform.localScale.z * boxSize.z) / 2,
                                                Quaternion.identity,
                                                    playerMask);

        ExtraAction(colliders);

        if (NotActive_)
        {
            cooldown -= Time.fixedDeltaTime;

            if (timer > 0)
                timer -= Time.fixedDeltaTime;
            else
            {
                light_.enabled = !light_.enabled;
                timer = cooldown / 8;
            }

            if (cooldown <= 0)
            {
                NotActive_ = false;
                cooldown = cooldownMax;
                light_.enabled = true;
                light_.color = Color.red;
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(
    //            new Vector3(transform.position.x + boxLocation.x, transform.position.y + boxLocation.y, transform.position.z + boxLocation.z),
    //                new Vector3(transform.localScale.x * boxSize.x, transform.localScale.y * boxSize.y, transform.localScale.z * boxSize.z));
    //}
}
