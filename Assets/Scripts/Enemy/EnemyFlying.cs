using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyFlying : Enemy
{

    public void Release(EnemyBehavior enemy, ObjectPooler objectPooler, EnemyType enemyType)
    {
        objectPooler.GetPool(enemyType).Release(enemy);
    }

    public EnemyBehavior Get(ObjectPooler objectPooler, EnemyType enemyType) 
    {
        return objectPooler.GetPool(enemyType).Get();
    }

    public Vector3 FollowTarget(Transform current, Transform target, float moveSpeed)
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, enemyMoveSpeed * Time.deltaTime);
        Vector3 newTarget = target.position;
        newTarget.y = 2.0f;
        return Vector3.Lerp(current.position, newTarget, moveSpeed * Time.deltaTime);
    }

}
