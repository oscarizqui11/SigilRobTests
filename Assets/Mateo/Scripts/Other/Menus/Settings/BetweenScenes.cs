using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScenes : MonoBehaviour
{
    private void Awake()
    {
        var DontDestroyBetweenScenes = FindObjectsOfType<BetweenScenes>();

        if (DontDestroyBetweenScenes.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
