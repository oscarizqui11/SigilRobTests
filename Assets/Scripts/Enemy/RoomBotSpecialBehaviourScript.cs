using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBotSpecialBehaviourScript : EnemyBehaviourScript
{
    [SerializeField] private float bounce;

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

    public override void Movement()
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

    public override void Action()
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

    public override void ExtraAction(Collider[] colliders)
    {
        if (0 < colliders.Length)
        {
            if (!isCollinding)
            {
                if (!NotActive_)
                {
                    NotActive_ = true;
                    light_.color = color_;
                }

                colliders[0].gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounce, ForceMode.Impulse);
            }

            isCollinding = true;
        }
        else
            isCollinding = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(
                new Vector3(transform.position.x + boxLocation.x, transform.position.y + boxLocation.y, transform.position.z + boxLocation.z),
                    new Vector3(transform.localScale.x * boxSize.x, transform.localScale.y * boxSize.y, transform.localScale.z * boxSize.z));
    }
}
