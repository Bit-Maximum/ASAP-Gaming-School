using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] private PlayerStatus levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStatus>(out var player))
        {
            player.ChageScore(score);
            gameObject.SetActive(false);
        }
    }
}
