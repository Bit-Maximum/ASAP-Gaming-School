using UnityEngine;

public class JumpBoots : MonoBehaviour, BootsInterface
{
    private float defaultJumpHight;
    [SerializeField] private GameObject player;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(audioManager);
    }

    public void AffectPlayer()
    {
        Debug.Log("Affect");
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        audioManager.PlaySFX(audioManager.Rock);
        Debug.Log("Affect 2");
        player = GameObject.FindGameObjectWithTag("Player");

        defaultJumpHight = player.GetComponent<PlayerMovement>().Data.jumpHeight;
        player.GetComponent<PlayerMovement>().Data.jumpHeight = 1.5f * defaultJumpHight;
        Debug.Log("Affect Close");

    }

    public void RestoreDefaultsPlayer()
    {
        Debug.Log("Restore");
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerMovement>().Data.jumpHeight = defaultJumpHight;
        Debug.Log("Restore Close");

    }
}
