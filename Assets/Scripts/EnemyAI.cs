using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Transform targetTransform;

    [Tooltip("Enemy move speed")]
    [SerializeField] float enemyMoveSpeed;

    [Tooltip("Distance to stop before reaching target")]
    [SerializeField] float stoppingDistance;

    void OnEnable()
    {
        targetTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);
        if (distanceToTarget <= stoppingDistance) return;
        
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, enemyMoveSpeed * Time.deltaTime);
    }
}
