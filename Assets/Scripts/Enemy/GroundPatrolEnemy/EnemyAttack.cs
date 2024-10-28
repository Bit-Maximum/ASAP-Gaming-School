using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool IsAggro = false;
    public float aggroRange;
    public float attackRange;
    public float chaseSpeed;
    public Transform player;


    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) <= aggroRange)
        {
            IsAggro = true;
        }
        else
        {
            IsAggro = false;
        }

        if (IsAggro)
        {
            if (Vector2.Distance(transform.position, player.position) > attackRange)
            {
                if (transform.position.y < player.position.y)
                {
                    // Set new Y-position to current Y-height to prevent enemy from flying towards the player
                    Vector3 targetPossition = new Vector3(player.position.x, transform.position.y, transform.position.z);
                    transform.position = Vector2.MoveTowards(transform.position, targetPossition, chaseSpeed * Time.fixedDeltaTime);
                }
                transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.fixedDeltaTime);
            }
            else
            {
                Debug.Log("Attack");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!player)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
