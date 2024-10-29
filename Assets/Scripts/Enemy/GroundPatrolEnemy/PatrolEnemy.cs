using UnityEngine;
using UnityEngine.TextCore;

public class PatrolEnemy : MonoBehaviour
{

    private EnemyAttack attackBehavior;
    private AnimetionPatrolEnemy AnimationControl;

    public Transform _checkPoint;
    public float cliffCheckRayDistance;

    public Transform _groundCheckPoint;
    public Vector2 _groundCheckSize;

    public float maxSpeed;
    public float maxFallSpeed;
    private bool IsFacingRight = true;

    public LayerMask _groundLayer;


    private void Awake()
    {
        attackBehavior = GetComponent<EnemyAttack>();
        AnimationControl = GetComponent<AnimetionPatrolEnemy>();
    }

    private void FixedUpdate()
    {
        //Ground Check
        if (!Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer))
        {
            transform.Translate(Vector2.down * Time.fixedDeltaTime * maxFallSpeed);
        }

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
            transform.Translate(Vector2.left * Time.fixedDeltaTime * maxSpeed);

            RaycastHit2D hit = Physics2D.Raycast(_checkPoint.position, Vector2.down, cliffCheckRayDistance, _groundLayer);

            if (!hit)
            {
                if (IsFacingRight)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                IsFacingRight = !IsFacingRight;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_checkPoint == null)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_checkPoint.position, Vector2.down * cliffCheckRayDistance);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
    }
}
