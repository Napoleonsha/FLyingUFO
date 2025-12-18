using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
    private void MainMenu ()
    {

    }
    private void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
