using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixerSFX;

    public TMP_Dropdown resolutionsDropdown;
    public TMP_Dropdown qualiyDropdown;
    public Slider VolumeSlider;
    public Slider SFXSlider;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
        qualiyDropdown.value = QualitySettings.GetQualityLevel();
        qualiyDropdown.RefreshShownValue();

        float value;
        bool result = audioMixer.GetFloat("volume", out value);
        VolumeSlider.normalizedValue = (value + 60) / 60;

        float valuesfx;
        bool resultSFX = audioMixerSFX.GetFloat("volumesfx", out valuesfx);
        SFXSlider.normalizedValue = (valuesfx + 60) / 60;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetVolume_SFX(float volumeSfx)
    {
        audioMixerSFX.SetFloat("volumesfx", volumeSfx);
    }
    public void SetQuality(int qualiity_index)
    {
        QualitySettings.SetQualityLevel(qualiity_index);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
