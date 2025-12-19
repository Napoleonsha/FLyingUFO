using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] Slider volume;
    AudioSource audioSource;

    public void Awake()
    {
        if (audioSource == null || volume == null)
            return;
        audioSource = GetComponent<AudioSource>();
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.volume = savedVolume;
        volume.value = savedVolume;
        volume.onValueChanged.AddListener(SetVolume);
        audioSource.Play();
        
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
