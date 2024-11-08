using Unity.Burst.Intrinsics;
using UnityEngine;

public class Yaga : MonoBehaviour
{
    [SerializeField] private GameObject summon;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var player))
        {
            if (player.IsEnteractive)
            {
                audioManager.PlaySFX(audioManager.PickUp);
                summon.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}

