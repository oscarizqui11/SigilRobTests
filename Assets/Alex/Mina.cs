using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour
{
    public GameObject explosionParticles;
    public int damage;

    void OnTriggerEnter(Collider other)
    {
        //Explode();

        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<LiveSystem>().TakeDamage(damage);
            Explode();
        }
    }

    void Explode()
    {
        //Instantiate(explosionParticles, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
