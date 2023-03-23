using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingBehaviour : MonoBehaviour
{
    public float cadency;
    public string meleeBullet;
    public string rangedBullet;
    public Vector3 gunPosition;

    private float time;
    private Vector3 eulerRotation;

    public int energyCost = 0;
    public MyIntEvent onShoot;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
         if(time >= cadency)
         {
            GameObject newBullet;

            if (Camera.main.TryGetComponent<CameraController>(out CameraController cam) && cam.GetIsFirstPerson())
            {
                newBullet = PoolingManager.Instance.GetPooledObject(rangedBullet);

                newBullet.transform.position = cam.transform.position + cam.transform.rotation * gunPosition;
                newBullet.transform.rotation = cam.transform.rotation;
            }
            else
            {
                newBullet = PoolingManager.Instance.GetPooledObject(meleeBullet);

                newBullet.transform.position = transform.position + transform.rotation * gunPosition;
                newBullet.transform.rotation = transform.rotation;
            }
            
            newBullet.SetActive(true);
            onShoot.Invoke(energyCost);
            time = 0;

         }
    }

    private void FixedUpdate()
    {
        time = time + Time.fixedDeltaTime;
    }
}
