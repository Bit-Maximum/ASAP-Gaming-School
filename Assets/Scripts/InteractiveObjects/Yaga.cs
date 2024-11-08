using Unity.Burst.Intrinsics;
using UnityEngine;

public class Yaga : MonoBehaviour
{
    [SerializeField] private GameObject summon;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var player))
        {
            if (player.IsEnteractive)
            {
                summon.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}

