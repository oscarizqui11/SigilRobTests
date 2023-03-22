using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectableTrigger : MonoBehaviour
{

    private bool colectable;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pulsa E para recojer");
        //Aplicar shader
        colectable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Desaplicar shader
        colectable = false;
    }

    private void Start()
    {
        colectable = false;
    }

    private void Update()
    {
        if(colectable == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }
}
