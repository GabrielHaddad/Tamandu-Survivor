using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Spawn enemy circle radius's size")]
    [SerializeField] [Range(1f, 50f)] float enemySpawnRadius;

    [Tooltip("Delay in secons to the enemy spawn")]
    [SerializeField] [Range(0.1f, 10f)] float enemyDelaySpawn = 1f;

    [Tooltip("Enemy gameobject to be instantiated")]
    [SerializeField] Enemy enemyPrefab;

    [Tooltip("Target to be spawn enemies around")]
    [SerializeField] Transform targetTransform;

    [Tooltip("Number of reusable enemies in the scene")]
    [SerializeField] int poolMaxSize;

    bool canSpawn;
    private IObjectPool<Enemy> enemyPool;

    void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(
            CreateEnemy,
            OnGet,
            OnRelease,
            ActionOnDestroy,
            maxSize: poolMaxSize);
    }

    public void SetPool(IObjectPool<Enemy> pool)
    {
        enemyPool = pool;
    }

    public IObjectPool<Enemy> GetPool()
    {
        return enemyPool;
    }

    Enemy CreateEnemy()
    {
        Vector2 randomInRadius = RandomPointOnUnitCircle(enemySpawnRadius);
        float xPos = targetTransform.position.x + randomInRadius.x;
        float zPos = targetTransform.position.z + randomInRadius.y;

        Vector3 spawnPosition = new Vector3(xPos, targetTransform.position.y, zPos);

        Enemy enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);

        enemy.SetPool(enemyPool);
        return enemy;
    }

    private void OnGet(Enemy enemy)
    {
        Vector2 randomInRadius = RandomPointOnUnitCircle(enemySpawnRadius);
        float xPos = targetTransform.position.x + randomInRadius.x;
        float zPos = targetTransform.position.z + randomInRadius.y;

        Vector3 spawnPosition = new Vector3(xPos, targetTransform.position.y, zPos);

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPosition;
    }

    private void OnRelease(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnEnable()
    {
        canSpawn = true;
        StartCoroutine(SpawnEnemies());
    }

    void OnDisable()
    {
        canSpawn = false;
        StopAllCoroutines();
    }

    IEnumerator SpawnEnemies()
    {
        while (canSpawn)
        {
            enemyPool.Get();
            yield return new WaitForSeconds(enemyDelaySpawn);
        }
    }

    public static Vector2 RandomPointOnUnitCircle(float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;

        return new Vector2(x, y);

    }
}
