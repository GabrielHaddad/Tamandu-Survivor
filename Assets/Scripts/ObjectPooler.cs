using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    [Tooltip("Number of reusable enemies in the scene")]
    [SerializeField] int poolMaxSizeGround;

    [Tooltip("Number of reusable enemies in the scene")]
    [SerializeField] int poolMaxSizeFlying;

    IObjectPool<EnemyBehavior> groundPool;
    IObjectPool<EnemyBehavior> flyingPool;

    EnemySpawner enemySpawner;

    void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();

        groundPool = new ObjectPool<EnemyBehavior>(
            CreateEnemy,
            OnGet,
            OnRelease,
            ActionOnDestroy,
            maxSize: poolMaxSizeGround);
        
        flyingPool = new ObjectPool<EnemyBehavior>(
            CreateEnemy,
            OnGet,
            OnRelease,
            ActionOnDestroy,
            maxSize: poolMaxSizeFlying);
    }

    public IObjectPool<EnemyBehavior> GetGroundPool()
    {
        return groundPool;
    }

    public IObjectPool<EnemyBehavior> GetFlyingPool()
    {
        return flyingPool;
    }

    EnemyBehavior CreateEnemy()
    {
        GameObject enemy = Instantiate(enemySpawner.GetCurrentEnemySpawned(), enemySpawner.RandomPositionOnCircunference(), Quaternion.identity, transform);
        EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
        enemyBehavior.Init(this);

        return enemyBehavior;
    }

    private void OnGet(EnemyBehavior enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = enemySpawner.RandomPositionOnCircunference();
    }

    private void OnRelease(EnemyBehavior enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(EnemyBehavior enemy)
    {
        Destroy(enemy.gameObject);
    }

}
