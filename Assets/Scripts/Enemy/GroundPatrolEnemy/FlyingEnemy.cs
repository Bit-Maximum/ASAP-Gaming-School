using System.Reflection;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UIElements;

public class FlyingEnemy : MonoBehaviour
{

    private FlyingEnemyAttack attackBehavior;
    private AnimetionPatrolEnemy AnimationControl;
    private EnemyStatus enemyStatus;

    public float ReturnDistance;
    public float maxSpeed;
    public bool IsFacingRight = false;

    [SerializeField] private Transform startingPosition;


    private void Awake()
    {
        attackBehavior = GetComponent<FlyingEnemyAttack>();
        AnimationControl = GetComponent<AnimetionPatrolEnemy>();
        enemyStatus = GetComponent<EnemyStatus>();
    }

    //private void Start()
    //{
    //    startingPosition = this.transform;
    //}

    private void FixedUpdate()
    {
        if (!enemyStatus.IsStuned)
        {
            // Flip to face Player
            if (attackBehavior.IsAggro)
            {
                if (attackBehavior.player.position.x < transform.position.x && IsFacingRight)
                {   
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    IsFacingRight = !IsFacingRight;
                }
                else if (attackBehavior.player.position.x > transform.position.x && !IsFacingRight)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    IsFacingRight = !IsFacingRight;
                }
            }

            // Otherwise start patrol
            if (!attackBehavior.IsAggro)
            {
                if (Vector2.Distance(transform.position, startingPosition.position) > ReturnDistance)
                {
                    if (transform.position.x < startingPosition.position.x)
                    {
                        if (!IsFacingRight)
                        {
                            transform.eulerAngles = new Vector3(0, 180, 0);
                            IsFacingRight = !IsFacingRight;
                        }
                    } else
                    {
                        if (IsFacingRight)
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            IsFacingRight = !IsFacingRight;
                        }
                    }
                    
                    transform.position = Vector2.MoveTowards(transform.position, startingPosition.position, maxSpeed * Time.fixedDeltaTime);
                }

            }
        }
    }

}
