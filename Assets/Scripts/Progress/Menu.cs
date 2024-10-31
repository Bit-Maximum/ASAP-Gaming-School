using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
