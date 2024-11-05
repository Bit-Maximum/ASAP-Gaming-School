using UnityEngine;


public class The : MonoBehaviour
{
    public static The Instance { get; private set; }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject groundEnemyPrefab;
    [SerializeField] GameObject flyingEnemyPrefab;


    private void Start()
    {
        if (Instance == null)
        {
            Instance ??= this;

            if (Instance == this)
            {
                DontDestroyOnLoad(gameObject);
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
