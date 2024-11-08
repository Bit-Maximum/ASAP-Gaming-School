using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
