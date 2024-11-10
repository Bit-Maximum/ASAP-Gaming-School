using UnityEngine;

public class JumpBoots : MonoBehaviour
{
    private float defaultJumpHight;
    [SerializeField] private GameObject player;

    public void AffectPlayer()
    {
        defaultJumpHight = player.GetComponent<PlayerMovement>().Data.jumpHeight;
        player.GetComponent<PlayerMovement>().Data.jumpHeight = 1.5f * defaultJumpHight;
    }

    public void RestoreDefaultsPlayer()
    {
        player.GetComponent<PlayerMovement>().Data.jumpHeight = defaultJumpHight;
    }
}
