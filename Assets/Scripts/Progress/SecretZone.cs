
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretZone : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            if (playerMovement.IsEnteractive)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}

