using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingBhFSM : MonoBehaviour
{
    public float cadency;
    public string meleeBullet;
    public string rangedBullet;
    public Vector3 gunPosition;

    private float time;
    private Vector3 eulerRotation;

    public int energyCost = 0;
    public MyIntEvent onShoot;

    /*private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }*/

    private void Start()
    {
        time = cadency;
    }

    public void Shoot(bool isRanged)
    {
        if (time >= cadency)
        {
            GameObject newBullet;

            if (isRanged)
            {
                newBullet = PoolingManager.Instance.GetPooledObject(rangedBullet);

                newBullet.transform.position = Camera.main.transform.position + Camera.main.transform.rotation * gunPosition;
                newBullet.transform.rotation = Camera.main.transform.rotation;
            }
            else
            {
                newBullet = PoolingManager.Instance.GetPooledObject(meleeBullet);

                newBullet.transform.position = transform.position + transform.rotation * gunPosition;
                newBullet.transform.rotation = transform.rotation;
            }

            newBullet.SetActive(true);
            onShoot.Invoke(energyCost);
            GetComponent<PlayerController>().battery -= energyCost;
            time = 0;

        }
    }

    private void FixedUpdate()
    {
        time = time + Time.fixedDeltaTime;
    }
}