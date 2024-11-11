using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Boots : MonoBehaviour
{
    [SerializeField] public Sprite bootSprite;
    [SerializeField] private GameObject bootsLogic;
    private AudioManager audioManager;

    private float PikedDelay = 1f;
    private float LastPickedTime = 0;
    private bool isReady = true;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        LastPickedTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (!isReady && LastPickedTime < 0)
            isReady = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isReady)
        {
            if (collision.TryGetComponent<PlayerMovement>(out var player))
            {
                if (player.IsEnteractive)
                {
                    audioManager.PlaySFX(audioManager.PickUp);

                    LastPickedTime = PikedDelay;
                    isReady = false;

                    BootsInterface playerBI = player.bootsLogic.GetComponent<BootsInterface>();
                    playerBI.RestoreDefaultsPlayer();

                    Sprite tempSprite = player.leftBoot.sprite;
                    player.leftBoot.sprite = bootSprite;
                    player.rightBoot.sprite = bootSprite;
                    bootSprite = tempSprite;
                    GetComponent<SpriteRenderer>().sprite = tempSprite;

                    // Uniqe Logic
                    GameObject tempLogic = player.bootsLogic;
                    player.bootsLogic = bootsLogic;
                    Debug.Log(player.bootsLogic.transform.name);
                    bootsLogic = tempLogic;
                    player.bootsLogic.GetComponent<BootsInterface>().AffectPlayer();
                }
            }
        }
    }
}
