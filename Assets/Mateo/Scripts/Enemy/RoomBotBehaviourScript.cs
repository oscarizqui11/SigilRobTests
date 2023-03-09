using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBotBehaviourScript : EnemyBehaviourScript
{
    public override void ExtraAction(Collider[] colliders)
    {
        if (0 < colliders.Length)
        {
            if (!isCollinding)
            {
                if (!NotActive_)
                {
                    NotActive_ = true;
                    timer = cooldownMax / 8;
                    light_.color = color_;
                }
                else
                {
                    NotActive_ = false;
                    cooldown = cooldownMax;
                    light_.enabled = true;
                    light_.color = Color.red;
                }
            }

            isCollinding = true;
        }
        else
            isCollinding = false;
    }
}