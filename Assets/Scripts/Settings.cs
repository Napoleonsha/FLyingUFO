using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;


public class Settings : MonoBehaviour
{
    private string fullScreenToggle = "Fullscreen";
    void Start()
    {
        bool isFullScreen = PlayerPrefs.GetInt(fullScreenToggle, 1) == 1;
        Screen.fullScreen = isFullScreen;
    }
    public void FullScreen(bool value)
    {
        Screen.fullScreen = !Screen.fullScreen;
        PlayerPrefs.SetInt(fullScreenToggle, Screen.fullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SetLanguage(string code)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(code);
        PlayerPrefs.SetString("Locales", code);
    }


}
