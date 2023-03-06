using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviourScript : MonoBehaviour
{
    #region Parameters
    [Header("Movement Parameters")]
    [SerializeField] protected Vector3[] pos;
    [SerializeField] protected float speed;
    [SerializeField] protected float speedRotation;

    protected Quaternion lookRotation;
    protected Vector3 dir;
    protected int index;
    
    [SerializeField] protected Vector3 boxLocation;
    [SerializeField] protected Vector3 boxSize;
    [SerializeField] protected LayerMask playerMask;

    protected Rigidbody rb_;
    protected bool isCollinding;

    [Header("Reactivated Parameters")]
    [SerializeField] protected float cooldownMax;
    [SerializeField] protected Light light_;
    [SerializeField] protected Color color_;

    protected float cooldown;
    protected float timer;
    public bool NotActive_ { protected set; get; }
    #endregion

    #region Interpolation
    protected float totalTime;
    protected float factor;
    protected float currentTime;

    protected bool assignedPoint;

    protected Vector3 pointA;
    protected Vector3 pointB;
    #endregion

    public abstract void Movement();
    public abstract void Action();
    public abstract void ExtraAction(Collider[] colliders);
}
