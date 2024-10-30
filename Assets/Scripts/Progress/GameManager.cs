using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameActive = true;

    public void PlayerDied()
    {
        StopTheGame();
    }

    public void StopTheGame()
    {
        isGameActive = false;
        Time.timeScale = 0;
    }

    public void ResumeTheFame()
    {
        isGameActive = true;
        Time.timeScale = 1;
    }

    public bool CurrentGameState()
    {
        return isGameActive;
    }
}
