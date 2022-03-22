using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyGround : Enemy
{

    public void Release(EnemyBehavior enemy, ObjectPooler objectPooler, EnemyType enemyType)
    {
        objectPooler.GetPool(enemyType).Release(enemy);
    }

    public void Get(ObjectPooler objectPooler, EnemyType enemyType) 
    {
        objectPooler.GetPool(enemyType).Get();
    }
    public Vector3 FollowTarget(Transform current, Transform target, float moveSpeed)
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, enemyMoveSpeed * Time.deltaTime);
        Vector3 newTarget = target.position;
        newTarget.y = 0.0f;
        return Vector3.Lerp(current.position, newTarget, moveSpeed * Time.deltaTime);
    }

}
