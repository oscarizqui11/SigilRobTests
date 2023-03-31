using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceManager : MonoBehaviour
{
    public GameObject inventory;

    public InputAction openInventoryAction;

    private void OnEnable()
    {
        openInventoryAction.Enable();
    }

    void Update()
    {
        if(openInventoryAction.triggered)
        {
            if (inventory.activeInHierarchy)
            {
                inventory.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                inventory.SetActive(true);
            }
        }        
    }
}
