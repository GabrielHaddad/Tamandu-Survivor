using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] List<int> poolsMaxSize = new List<int>();
    Dictionary<int, IObjectPool<EnemyBehavior>> enemyPools = new Dictionary<int, IObjectPool<EnemyBehavior>>();

    EnemySpawner enemySpawner;

    void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();

        InitiatePools();
    }

    void InitiatePools()
    {
        foreach (string name in System.Enum.GetNames(typeof(EnemyType)))
        {
            int type = (int)System.Enum.Parse(typeof(EnemyType), name);
            enemyPools.Add(type, new ObjectPool<EnemyBehavior>(CreateEnemy, OnGet, OnRelease, ActionOnDestroy, maxSize: poolsMaxSize[type]));
        }
    }

    public IObjectPool<EnemyBehavior> GetPool(EnemyType enemyType)
    {
        int type = (int)System.Enum.Parse(typeof(EnemyType), System.Enum.GetName(typeof(EnemyType), enemyType));
        return enemyPools[type];
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
