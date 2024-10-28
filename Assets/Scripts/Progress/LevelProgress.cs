using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;

    public int score = 0;

    public void ChangeScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score" + score.ToString();
    }
}
