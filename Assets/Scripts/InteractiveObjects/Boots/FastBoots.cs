using UnityEngine;

public class FastBoots : MonoBehaviour, BootsInterface
{
    private float defaultRunMaxSpeed;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AffectPlayer()
    {
        defaultRunMaxSpeed = player.GetComponent<PlayerMovement>().Data.runMaxSpeed;
        player.GetComponent<PlayerMovement>().Data.runMaxSpeed = 1.5f * defaultRunMaxSpeed;
    }

    public void RestoreDefaultsPlayer()
    {
        player.GetComponent<PlayerMovement>().Data.runMaxSpeed = defaultRunMaxSpeed;
    }
}
