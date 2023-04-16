using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    private Slider sliderVolume;
    public AudioMixer audioMixer;

    private Toggle pleineEcran;

    private Button btnRetour;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        
        sliderVolume = GameObject.Find("Slider").GetComponent<Slider>();
        sliderVolume.onValueChanged.AddListener(SetVolume);

        pleineEcran = GameObject.Find("Toggle").GetComponent<Toggle>();
        pleineEcran.onValueChanged.AddListener(setFullScreen);

        
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

       
        btnRetour = GameObject.Find("Retour").GetComponent<Button>();
        btnRetour.onClick.AddListener(Retour);
    }

    void Retour()
    {
        GameObject panel = GameObject.Find("PanelSettings");
        panel.SetActive(false);
    }
    void SetVolume(float volume)
    {
        Debug.Log("Volume réglé à : " + volume);
        audioMixer.SetFloat("volume", volume);
    }

    void setFullScreen(bool isFullScreen)
    {
        Debug.Log("Mode pleine écran : " + isFullScreen);
        Screen.fullScreen = isFullScreen;
    }
}
