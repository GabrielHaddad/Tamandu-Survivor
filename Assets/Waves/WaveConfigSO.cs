using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] EnemyWaveConfig[] enemyWaveConfigs;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimunSpawnTime = 0.2f;

    [System.Serializable]
    public class EnemyWaveConfig
    {
        [Tooltip("Enemy GameObject")]
        public GameObject enemyPrefab;

        [Tooltip("Amount of this enemy in the current wave")]
        public int enemyAmount;
    }

    public int GetEnemyWaveConfigCount()
    {
        return enemyWaveConfigs.Length;
    }

    public EnemyWaveConfig[] GetEnemyWaveConfig()
    {
        return enemyWaveConfigs;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
    
        return Mathf.Clamp(spawnTime, minimunSpawnTime, float.MaxValue);
    }
}

