using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplite : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            if (playerMovement.IsEnteractive)
            {
                gameManager.StopTheGame();
                gameManager.PlayerWin();
            }
        }
    }
}
