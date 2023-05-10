using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject target;
    public bool vision;
    private Vector3 direction;

    private void FixedUpdate()
    {
        if (vision)
        {
            direction = target.transform.position - transform.position;
            RaycastHit hit;
            int layerMask = LayerMask.GetMask("Ignore Raycast");

            if (Physics.Raycast(transform.position, direction.normalized, out hit, 100, ~layerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    OnVision();
                }
            }
        }
    }

    private void OnVision()
    {
        transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
    }

}
