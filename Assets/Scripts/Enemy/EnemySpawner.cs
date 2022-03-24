using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Spawn enemy circle radius's size")]
    [SerializeField][Range(1f, 50f)] float enemySpawnRadius;

    [Tooltip("Target to be spawn enemies around")]
    [SerializeField] Transform targetTransform;

    [Tooltip("List of subsequent waves")]
    [SerializeField] List<WaveConfigSO> waveConfigs;

    [Tooltip("Time delay before spawning next wave")]
    [SerializeField] float timeBetweenWaves = 1f;

    public event Action onLoopChange;

    bool canSpawn;
    int waveLoops = 0;
    WaveConfigSO currentWave;
    GameObject currentEnemySpawned;
    ObjectPooler objectPooler;

    void Awake()
    {
        objectPooler = GetComponent<ObjectPooler>();
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
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;

                if (onLoopChange != null)
                {
                    onLoopChange();
                }

                for (int i = 0; i < wave.GetEnemyWaveConfigCount(); i++)
                {
                    WaveConfigSO.EnemyWaveConfig currentEnemyConfig = wave.GetEnemyWaveConfig()[i];
                    currentEnemySpawned = currentEnemyConfig.enemyPrefab;
                    int enemyAmount = currentEnemyConfig.enemyAmount;

                    for (int j = 0; j < enemyAmount; j++)
                    {
                        EnemyBehavior enemyBehavior = currentEnemySpawned.GetComponent<EnemyBehavior>();
        
                        enemyBehavior.Init(objectPooler);
                        EnemyBehavior instance = enemyBehavior.GetFromPool();

                        instance.SetEnemySpeed(currentEnemyConfig.moveSpeed + (waveLoops * currentEnemyConfig.moveSpeedIncrease));
                        instance.SetEnemyDamage(currentEnemyConfig.enemyDamage + (waveLoops * currentEnemyConfig.enemyDamageIncrease));
                        

                        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                    }
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }

            waveLoops++;
        }
    }

    public int GetCurrentWaveNumber()
    {
        return (waveLoops * waveConfigs.Count) + (waveConfigs.IndexOf(currentWave) + 1);
    }

    public GameObject GetCurrentEnemySpawned()
    {
        return currentEnemySpawned;
    }

    Vector2 RandomPointOnUnitCircle(float radius)
    {
        float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;

        return new Vector2(x, y);

    }

    public Vector3 RandomPositionOnCircunference()
    {
        Vector2 randomInRadius = RandomPointOnUnitCircle(enemySpawnRadius);
        float xPos = targetTransform.position.x + randomInRadius.x;
        float zPos = targetTransform.position.z + randomInRadius.y;

        return new Vector3(xPos, targetTransform.position.y, zPos);
    }
}
