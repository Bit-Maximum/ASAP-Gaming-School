using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{

    public PlayerData Data;


    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * Time.fixedDeltaTime * Data.runMaxSpeed);
    }
}
