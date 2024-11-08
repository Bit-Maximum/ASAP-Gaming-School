using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] private PlayerStatus levelManager;
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
            gameObject.SetActive(false);
        }
    }
}
