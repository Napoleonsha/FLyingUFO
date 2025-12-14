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
    }
    
    public void SureExit ()
    {

    }
}
