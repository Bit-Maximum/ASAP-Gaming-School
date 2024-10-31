using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool isGameActive = true;
    [SerializeField] private List<GameObject> LevelsList;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerStatus playerStatus;

    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private TMP_Text victoryScore;
    [SerializeField] private TMP_Text ballsScore;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text gameOverScore;

    private float runMaxSpeed;
    private float jumpHeigh;

    private void Awake()
    {
        for (int i = 0; i < LevelsList.Count; ++i)
        {
            LevelsList[i].SetActive(false);
        }

        if (LevelsList.Count > 0)
            LevelsList[0].SetActive(true);

        runMaxSpeed = playerData.runMaxSpeed;
        jumpHeigh = playerData.jumpHeight;
    }

    public void PlayerDied()
    {
        gameOverScore.text = "" + playerStatus.GetScore();
        gameOverScreen.SetActive(true);
        StopTheGame();
    }

    public void PlayerWin()
    {
        victoryScore.text = "" + playerStatus.GetScore();
        ballsScore.text = "" + playerStatus.ballsCounter;
        victoryScreen.SetActive(true);
        StopTheGame();
    }

    public void StopTheGame()
    {
        isGameActive = false;
        Time.timeScale = 0;
    }

    public void ResumeTheGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
    }

    public bool CurrentGameState()
    {
        return isGameActive;
    }

    public void ResetScene()
    {
        ResetValues();
        ResumeTheGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToNextScene()
    {
        ResetValues();
        ResumeTheGame();
        SceneManager.LoadScene("Scene2");
    }

    public void ReturnToMenu()
    {
        ResetValues();
        ResumeTheGame();
        SceneManager.LoadScene("Menu");
    }

    private void ResetValues()
    {
        playerData.runMaxSpeed = runMaxSpeed;
        playerData.jumpHeight = jumpHeigh;
    }
}
