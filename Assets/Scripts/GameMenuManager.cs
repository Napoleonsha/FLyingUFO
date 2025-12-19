using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject UI;

    public void Pause()
    {
        UI.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitPause()
    {
        pauseMenu.SetActive(false);
        UI.SetActive(true);
        Time.timeScale = 1;
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
