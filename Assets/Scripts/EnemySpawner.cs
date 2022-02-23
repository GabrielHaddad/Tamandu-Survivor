using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Spawn enemy circle radius's size")]
    [SerializeField] [Range(1f, 50f)] float enemySpawnRadius;

    [Tooltip("Delay in secons to the enemy spawn")]
    [SerializeField] [Range(0.1f, 10f)] float enemyDelaySpawn = 1f;

    [Tooltip("Enemy gameobject to be instantiated")]
    [SerializeField] GameObject enemyPrefab;

    [Tooltip("Target to be spawn enemies around")]
    [SerializeField] Transform targetTransform;

    bool canSpawn;

    void OnEnable()
    {
        canSpawn = true;
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        while (canSpawn)
        {
            Vector2 randomInRadius = RandomPointOnUnitCircle(enemySpawnRadius);
            float xPos = targetTransform.position.x + randomInRadius.x;
            float zPos = targetTransform.position.z + randomInRadius.y;

            Vector3 spawnPosition = new Vector3(xPos, targetTransform.position.y, zPos);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
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
