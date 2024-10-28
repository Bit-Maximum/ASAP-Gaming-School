using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] public int score;

    private LevelManager levelManager;

    public void SetLevelManager(LevelManager manager)
    {
        levelManager = manager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStatus>(out var player))
        {
            player.ChageScore(score);
            gameObject.SetActive(false);
        }
    }
}
