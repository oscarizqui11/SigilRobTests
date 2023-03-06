using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce;

    [SerializeField]
    [Range(0, 1)]
    [Tooltip("If the collider is a capsule, how much radius is added to the bottom of the collider to detect the collision with the ground.")]
    float stepHeight;

    private Rigidbody _rb;
    private CapsuleCollider _capscol;

    public bool Grounded { get { return grounded; } private set { grounded = value; } }

    [SerializeField]
    private bool grounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _capscol = GetComponent<CapsuleCollider>();

        grounded = true;
    }

    void Update()
    {
        if(grounded && Input.GetButtonDown("Jump"))
        {
            if(!Camera.main.GetComponentInChildren<CameraController>().GetIsFirstPerson())
                _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        /*if(LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
        {
            grounded = true;
        }*/

        /*ContactPoint contact = collision.GetContact(0);

        if(contact.point.y < transform.position.y)
        {
            Debug.Log("Caida!");
            grounded = true;
        }*/

        foreach(ContactPoint point in collision.contacts)
        {
            //Debug.Log(point.point.y + ", " + (transform.position.y + _capscol.center.y - _capscol.height / 2 + _capscol.radius));
            
            if(point.point.y <= StepPointY())
            {
                Debug.Log(collision.collider.bounds.max.y);
                Debug.Log("Caida!");
                grounded = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        /*if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
        {
            grounded = false;
        }*/
        //if (collision.collider.bounds.ClosestPoint(transform.position + _capscol.center - new Vector3(0, _capscol.height / 2 + _capscol.radius / 2, 0)).y < transform.position.y + _capscol.center.y - _capscol.height / 2 + _capscol.radius / 2)
        if (transform.position.y + _capscol.center.y - _capscol.height / 2 + _capscol.radius * stepHeight - collision.collider.bounds.ClosestPoint(transform.position + _capscol.center - new Vector3(0, _capscol.height / 2 + _capscol.radius * stepHeight, 0)).y > 0.05f)
        {
            Debug.Log(collision.gameObject.name + ", " + collision.collider.bounds.ClosestPoint(transform.position + _capscol.center - new Vector3(0, _capscol.height / 2 + _capscol.radius / 2, 0)).y);
            Debug.Log(transform.position.y + _capscol.center.y - _capscol.height / 2 + _capscol.radius * stepHeight);
            Debug.Log("Salto!");
            grounded = false;
        }
    }

    private Vector3 StepPoint()
    {
        return transform.position + _capscol.center - new Vector3(0, _capscol.height / 2 + _capscol.radius * stepHeight, 0);
    }

    private float StepPointY()
    {
        return transform.position.y + _capscol.center.y - _capscol.height / 2 + _capscol.radius * stepHeight;
    }
}
