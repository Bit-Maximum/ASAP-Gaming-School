using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStatus>(out var player))
        {
            player.ChageScore(score);
            player.UpdateBallsLeftCounter();
            gameObject.SetActive(false);
        }
    }
}
