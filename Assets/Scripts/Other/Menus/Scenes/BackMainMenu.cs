using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviour
{
    public void MainMenu(string MainMenuName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuName);
    }
}
