using UnityEngine.SceneManagement;
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
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.volume = savedVolume;

        if (volume)
        {
            volume.SetValueWithoutNotify(savedVolume);
            volume.onValueChanged.AddListener(setVolume);
        }
        audioSource.Play();
        SceneManager.sceneLoaded += onSceneLoaded;
        
    }
    public void onSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        var newSlider = FindAnyObjectByType<Slider>();
        if (!newSlider)
        {
            return;
        }
        volume = newSlider;

        volume.SetValueWithoutNotify(audioSource.volume);
        volume.onValueChanged.RemoveAllListeners();
        volume.onValueChanged.AddListener(setVolume);
    }
    public void setVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void OnDestroy()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;

    }
}
