using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager pauseManager_;

    //Menus Var
    [SerializeField] private GameObject pauseMenu_;
    [SerializeField] private string MainMenuName;

    private bool subMenuOn;

    private void Awake()
    {
        if (pauseManager_ == null)
        {
            pauseManager_ = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
            Destroy(gameObject);

        subMenuOn = false;
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != MainMenuName && !subMenuOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameManager._gameManager.gameState == 1)
                {
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.Locked;

                    GameManager._gameManager.gameState = 0;
                    pauseMenu_.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0f;
                    Cursor.lockState = CursorLockMode.None;

                    GameManager._gameManager.gameState = 1;
                    pauseMenu_.SetActive(true);
                }
            }
        }
    }

    public void SubMenu()
    {
        if (!subMenuOn)
            subMenuOn = true;
        else
            subMenuOn = false;
    }
}