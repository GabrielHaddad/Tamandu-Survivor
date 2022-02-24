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

    public void Get(ObjectPooler objectPooler, EnemyType enemyType) 
    {
        objectPooler.GetPool(enemyType).Get();
    }

}
