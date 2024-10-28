using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] public Transform targetPoint;
    [SerializeField] public float speed;

    private Vector2 originalPoint;
    private Vector2 currentTargetPoint;
    private Rigidbody2D RB;

    private void Awake()
    {
        originalPoint = transform.position;
        RB = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
       if(Vector2.Distance(RB.position, currentTargetPoint) < 0.1f)
        {
            if (currentTargetPoint == originalPoint)
            {
                currentTargetPoint = targetPoint.position;
            } else
            {
                currentTargetPoint = originalPoint;
            }
       }

        var direction = (currentTargetPoint - RB.position).normalized;
        RB.velocity = direction * speed;
    }
}
