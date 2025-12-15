using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;


public class Settings : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resolution;

    private string fullScreenToggle = "Fullscreen";
    Resolution[] resolutions;

    public void Start()
    {
        bool isFullScreen = PlayerPrefs.GetInt(fullScreenToggle, 1) == 1;
        Screen.fullScreen = isFullScreen;

        resolution.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int resIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resIndex = i;
            }
        }
        resolution.AddOptions(options);
        resolution.RefreshShownValue();
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolution.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolution.value = resIndex;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(PlayerPrefs.GetString("Locales"));
    }
    public void fullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        PlayerPrefs.SetInt(fullScreenToggle, Screen.fullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void setLanguage(string code)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(code);
        PlayerPrefs.SetString("Locales", code);
    }

    public void setRes(int resolutionInd)
    {
        Resolution res = resolutions[resolutionInd];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionInd);
        PlayerPrefs.Save();
    }
}
