using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject menuExit;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    
    public void SureExit ()
    {
        mainMenu.SetActive(false);
        menuExit.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void NoExit()
    {
        menuExit.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void EnterSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
    public void ExitSettings()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }

}
