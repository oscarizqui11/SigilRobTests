using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRobEngine
{
    public class CollisionEvents : MonoBehaviour
    {
        private void OnCollisionStay(Collision collision)
        {
            Debug.Log("Choca?");
        }
    }
}
