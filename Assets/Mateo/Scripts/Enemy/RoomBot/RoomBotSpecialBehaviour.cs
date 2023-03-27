using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBotSpecialBehaviour : RoomBotCollisionBehaviour
{
    [SerializeField] private float bounce;

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

                colliders[0].gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * bounce;
            }

            isCollinding = true;
        }
        else
            isCollinding = false;
    }
}
