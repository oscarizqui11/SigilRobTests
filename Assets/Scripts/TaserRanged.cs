using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserRanged : MonoBehaviour
{
    private MovementBehaviour _mb;

    float taserDuration = 2f;
    float taserTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _mb = GetComponent<MovementBehaviour>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _mb.MoveRB(transform.forward);

        if (taserTimer > 0)
        {
            taserTimer -= Time.fixedDeltaTime;
        }
        else
        {
            taserTimer = 0f;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        taserTimer = taserDuration;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
