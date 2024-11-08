using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] public int score;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStatus>(out var player))
        {
            audioManager.PlaySFX(audioManager.PickUp);
            player.ChageScore(score);
            player.UpdateBallsLeftCounter();
            gameObject.SetActive(false);
        }
    }
}
