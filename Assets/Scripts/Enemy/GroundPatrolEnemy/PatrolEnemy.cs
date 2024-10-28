using UnityEngine;
using UnityEngine.TextCore;

public class PatrolEnemy : MonoBehaviour
{

    public Transform checkPoint;
    public float groundCheckRayDistance;

    public float maxSpeed;
    private bool IsFacingRight = true;

    public LayerMask _groundLayer;

    private EnemyAttack attackBehavior;

    private void Awake()
    {
        attackBehavior = GetComponent<EnemyAttack>();
    }

    private void FixedUpdate()
    {

        if (!attackBehavior.IsAggro)
        {
            transform.Translate(Vector2.left * Time.fixedDeltaTime * maxSpeed);

            RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, Vector2.down, groundCheckRayDistance, _groundLayer);

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
        if (checkPoint == null)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(checkPoint.position, Vector2.down * groundCheckRayDistance);
    }
}
