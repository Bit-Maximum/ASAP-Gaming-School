using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;

public class PlayerForseField : MonoBehaviour
{
    [SerializeField] public PlayerMovement player;
    [SerializeField] public int damageFromTaran;

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.TryGetComponent<EnemyStatus>(out _))
        {
            int collisionDirection = 1;
            if (player.transform.position.x < collision.transform.position.x)
                collisionDirection = -1;

            player.playerStatus.TakeDamage(damageFromTaran);
            player.playerStatus.StunTaranPlayer(collisionDirection);
        }

        if (collision.TryGetComponent<HidenArea>(out HidenArea HA))
        {
            HA.SetTransparent();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HidenArea>(out HidenArea HA))
        {
            HA.SetVisible();
        }
    }

}
