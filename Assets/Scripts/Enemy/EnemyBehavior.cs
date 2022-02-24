using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBehavior : MonoBehaviour
{
    [Tooltip("Enemy damage")]
    [SerializeField] int damage = 10;
    public int Damage => damage;

    [SerializeField] EnemyType enemyType;
    [SerializeField] Enemy currentBehavior = new EnemyGround();
    ObjectPooler objectPooler;

    public void Init(ObjectPooler objectPooler) 
    {
        switch (enemyType)
        {
            case EnemyType.Ground:
            currentBehavior = new EnemyGround();
            break;

            case EnemyType.Flying:
            currentBehavior = new EnemyFlying();
            break;
        }
        this.objectPooler = objectPooler;
    }

    public void ReleaseEnemy()
    {
        currentBehavior.Release(this, objectPooler, enemyType);
    }

    public void GetFromPool()
    {
        currentBehavior.Get(objectPooler, enemyType);
    }
}
