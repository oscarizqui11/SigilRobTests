using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambot : MonoBehaviour
{
    public Transform target;
    public bool persecution;
    public float maxDistance;
    public GameObject cone;
    public Vector3 defaultRotation;
    private Vector3 direction;
    private Vector3 defaultPosition;
    private Vector3 DP;
    private MovementBH mv;
    public float backTime;
    private float time;

    void Start()
    {
        mv = GetComponent<MovementBH>();
        defaultPosition = transform.position;
    }

    private void FixedUpdate()
    {
        DP = defaultPosition - transform.position;

        if (persecution)
        {
            direction = target.position - transform.position;
            time = 0;
            RaycastHit hit;
            int layerMask = LayerMask.GetMask("Ignore Raycast");

            if (Physics.Raycast(transform.position, direction.normalized, out hit, maxDistance, ~layerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // Realizar acciones de seguimiento
                    Follow();
                }
                else
                {
                    persecution = false;
                }
            }
            else
            {
                persecution = false;
            }
        }
        else
        {
            time = time + Time.deltaTime;
            if(time >= backTime)
            {
                UnFollow();
            }
        }
        
    }

    private void Follow()
    {
        cone.SetActive(false);
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        mv.MoveRB(direction.normalized);
    }
    private void UnFollow()
    {
        mv.MoveRB(DP.normalized);
        transform.LookAt(new Vector3(defaultPosition.x, transform.position.y, defaultPosition.z));
    }

    public void CambotReset()
    {
        cone.SetActive(true);
        transform.position = defaultPosition;
        transform.LookAt(cone.transform);
    }
}
