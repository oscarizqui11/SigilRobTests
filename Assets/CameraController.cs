using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _cam;
    private Transform _player;

    private bool isFirstPerson;
    private Vector3 camPosition;
    private Quaternion camRotation;

    void Start()
    {
        _cam = GetComponent<Camera>();
        _player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if(Input.GetButtonDown("FirstPerson"))
        {
            ToggleFirstPerson();
        }
    }

    private void ToggleFirstPerson()
    {
        isFirstPerson = !isFirstPerson;
        
        _player.GetComponent<MeshRenderer>().enabled = !isFirstPerson;

        if(isFirstPerson)
        {
            _cam.transform.position = _player.position;
            _cam.transform.rotation = _player.rotation;
        }
        else
        {
            _cam.transform.position = camPosition;
            _cam.transform.rotation = camRotation;
        }
    }

    public void SetCameraPosition(Vector3 newPos)
    {
        _cam.transform.position = newPos;
    }

    public void SetCameraRotation(Quaternion newRotation)
    {
        _cam.transform.rotation = newRotation;
    }
}
