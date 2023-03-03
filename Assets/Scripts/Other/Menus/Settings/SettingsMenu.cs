using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    //Parametros del volumen

    [Header("Volume Setting")]
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 0.5f;

    //Parametros de los gráficos

    [Header("Graphics Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private float defaultbrightness = 0.5f;
    [SerializeField] private Image brightnessPanel;
    private float brightnessLevel_;

    [SerializeField] private TMP_Dropdown qualityDropdown;
    private int qualityLevel_;

    //Parametros de la resolución

    [Header("Resolution Dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        //Lista las opciones de resolución posible

        resolutions = Screen.resolutions;

        if (resolutions == null)
            Debug.Log("Null Start");

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 2; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetVolume(float volume)
    {
        //Ajusta el volumen

        AudioListener.volume = volume;
    }

    public void SetResolution(int resolutionIndex)
    {
        //Ajusta la resolución

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetBrightness(float brightness)
    {
        //Ajusta el brillo

        brightnessLevel_ = brightness;
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, brightnessSlider.value);
    }

    public void SetQuality(int qualityIndex)
    {
        //Ajusta la calidad de texturas

        qualityLevel_ = qualityIndex;
    }

    public void ApplySetting()
    {
        //Aplica los cambios en los ajustes

        PlayerPrefs.SetFloat("masterBrightness", brightnessLevel_);

        PlayerPrefs.SetInt("masterQuality", qualityLevel_);
        QualitySettings.SetQualityLevel(qualityLevel_);

        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }

    public void ResetButton()
    {
        //Resetea los ajustes
        //Volumen
        AudioListener.volume = defaultVolume;
        volumeSlider.value = defaultVolume;

        //Iluminación
        brightnessSlider.value = defaultbrightness;

        //Calidad
        qualityDropdown.value = 1;
        QualitySettings.SetQualityLevel(1);

        //Resolución
        Resolution currentResolution = Screen.currentResolution;
        Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
        
        if(resolutions != null)
            resolutionDropdown.value = resolutions.Length;

        ApplySetting();
    }
}
