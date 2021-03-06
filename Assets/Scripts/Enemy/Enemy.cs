using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    void Release(EnemyBehavior enemy, ObjectPooler objectPooler, EnemyType enemyType);
    EnemyBehavior Get(ObjectPooler objectPooler, EnemyType enemyType);
    Vector3 FollowTarget(Transform current, Transform target, float moveSpeed);
}
