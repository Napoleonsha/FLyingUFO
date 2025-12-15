using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] Slider volume;
    AudioSource audioSource;

    public void Awake()
    {
        if (FindObjectsByType<Music>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        if (volume)
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
            audioSource.volume = savedVolume;
            volume.value = savedVolume;
        }
        
    }
    public void setVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
