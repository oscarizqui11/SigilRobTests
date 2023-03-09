using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainSettings : MonoBehaviour
{
    SettingsController settingsController_;

    private void Start()
    { settingsController_ = GameObject.FindGameObjectWithTag("Options").GetComponent<SettingsController>(); }

    public void SetActiveOptions()
    { settingsController_.settingsMenu.SetActive(true); }
}
