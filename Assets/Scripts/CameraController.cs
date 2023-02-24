using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _cam;
    private Transform _player;

    private bool isFirstPerson;
    private Vector3 fixedCamPosition;
    private Quaternion fixedCamRotation;
    private float xRotation;
    [SerializeField] float camSensibility = 100;
    [SerializeField] float camHeight;

    void Start()
    {
        _cam = GetComponent<Camera>();
        _player = FindObjectOfType<PlayerController>().transform;
     
        fixedCamPosition = _cam.transform.position;
        fixedCamRotation = _cam.transform.rotation;
    }

    void FixedUpdate()
    {
        if(Input.GetButtonDown("FirstPerson") && _player.GetComponent<JumpController>().Grounded)
        {
            ToggleFirstPerson();
        }
        if(isFirstPerson)
        {
            if(_player.transform.position.x != _cam.transform.position.x &&
                _player.transform.position.y != _cam.transform.position.y)
            {
                ToggleFirstPerson();
            }

            float mouseX = Input.GetAxisRaw("Mouse X") * camSensibility * Time.fixedDeltaTime;
            xRotation += Input.GetAxisRaw("Mouse Y") * camSensibility * Time.fixedDeltaTime;

            xRotation = Mathf.Clamp(xRotation, -80, 80);

            _cam.transform.eulerAngles = new Vector3(-xRotation, _cam.transform.eulerAngles.y + mouseX, 0);
        }
    }

    private void ToggleFirstPerson()
    {
        isFirstPerson = !isFirstPerson;
        
        _player.GetComponent<MeshRenderer>().enabled = !isFirstPerson;

        if(isFirstPerson)
        {
            _cam.transform.position = _player.position + new Vector3(0, camHeight, 0);
            _cam.transform.rotation = _player.rotation;
        }
        else
        {
            _cam.transform.position = fixedCamPosition;
            _cam.transform.rotation = fixedCamRotation;
        }
    }

    public void SetCameraPosition(Vector3 newPos)
    {
        _cam.transform.position = newPos;
        fixedCamPosition = newPos;
    }

    public void SetCameraRotation(Quaternion newRotation)
    {
        _cam.transform.rotation = newRotation;
        fixedCamRotation = newRotation;
    }
}
