using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int scoreMultyplier = 1;

    [SerializeField] private int maxHealth = 3;

    #region Setters
    public void ChageScore(int amount)
    {
        score += amount * scoreMultyplier;
    }

    public void TakeDamage(int amount)
    {
        maxHealth -= amount;
        if (maxHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        maxHealth += amount;
    }

    public void DropScoreMultyplier()
    {
        scoreMultyplier = 1;
    }

    public void ChangeScoreMultyplier(int amount)
    {
        scoreMultyplier += amount;
    }
    #endregion

    #region Getters
    public int GetScore()
    {
        return score;
    }

    public int GetScoreMultyplier()
    {
        return scoreMultyplier;
    }

    public int GetCurrentHealth()
    {
        return maxHealth;
    }
    #endregion

    private void Die()
    {
        Debug.Log("Player died :(");
    }
}
