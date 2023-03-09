using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelScript : MonoBehaviour
{
    [SerializeField] private GameObject UI_Screen;
    [SerializeField] private Slider UI_Bar;
    [SerializeField] private string BGM;
    
    private float target_;

    public async void LoadScene(string sceneName)
    {
        target_ = 0;
        UI_Bar.value = 0;
        Time.timeScale = 1;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        UI_Screen.SetActive(true);

        do {
            await Task.Delay(100);
            target_ = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        FindObjectOfType<AudioManager>().PlayMusic(BGM);
    }

    private void Update()
    { UI_Bar.value = Mathf.MoveTowards(UI_Bar.value, target_, 3 * Time.deltaTime); }
}
