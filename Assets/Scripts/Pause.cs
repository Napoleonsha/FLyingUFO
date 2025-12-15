using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject UI;

    public void pause()
    {
        UI.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void backToMenu ()
    {
        SceneManager.LoadScene(0);
    }

    public void exitPause()
    {
        pauseMenu.SetActive(false);
        UI.SetActive(true);
        Time.timeScale = 1;
    }
}
