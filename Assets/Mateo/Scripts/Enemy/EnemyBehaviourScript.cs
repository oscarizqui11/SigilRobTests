using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviourScript : MonoBehaviour
{
    #region Parameters
    [Header("Movement Parameters")]
    [SerializeField] private Vector3[] pos;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;

    protected Quaternion lookRotation;
    protected Vector3 dir;
    protected int index;
    
    [SerializeField] private Vector3 boxLocation;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask playerMask;

    private Rigidbody rb_;
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
    private float totalTime;
    private float factor;
    private float currentTime;

    private bool assignedPoint;

    private Vector3 pointA;
    private Vector3 pointB;
    #endregion

    public abstract void ExtraAction(Collider[] colliders);

    private void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        cooldown = cooldownMax;
    }

    private void Update()
    {
        Action();
        Movement();
    }

    private void Movement()
    {
        if (!NotActive_)
        {
            if (!assignedPoint)
            {
                pointA = transform.position;
                pointB = pos[index];

                float dist = Vector3.Distance(pointA, pointB);

                totalTime = dist / speed;
                assignedPoint = true;

                dir = (pointB - pointA).normalized;
                lookRotation = Quaternion.LookRotation(dir);
            }

            currentTime += Time.deltaTime;
            factor = currentTime / totalTime;

            Vector3 valueIPos = pointA + (pointB - pointA) * factor;
            transform.position = valueIPos;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speedRotation);

            if (currentTime > totalTime)
            {
                currentTime = 0;
                assignedPoint = false;

                if (index < pos.Length - 1)
                    index++;
                else
                    index = 0;
            }
        }
    }

    private void Action()
    {
        Collider[] colliders = Physics.OverlapBox(
                                        new Vector3(transform.position.x + boxLocation.x, transform.position.y + boxLocation.y, transform.position.z + boxLocation.z),
                                            new Vector3(transform.localScale.x * boxSize.x, transform.localScale.y * boxSize.y, transform.localScale.z * boxSize.z) / 2,
                                                Quaternion.identity,
                                                    playerMask);

        ExtraAction(colliders);

        if (NotActive_)
        {
            cooldown -= Time.deltaTime;

            if (timer > 0)
                timer -= Time.deltaTime;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(
                new Vector3(transform.position.x + boxLocation.x, transform.position.y + boxLocation.y, transform.position.z + boxLocation.z),
                    new Vector3(transform.localScale.x * boxSize.x, transform.localScale.y * boxSize.y, transform.localScale.z * boxSize.z));
    }
}
