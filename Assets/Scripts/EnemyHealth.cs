using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Enemy health")]
    [SerializeField] int maxHealth = 10;
    int currentHealth;
    Enemy enemy;

    void Awake() 
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable() 
    {
        currentHealth = maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();
    }

    void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        enemy.GetPool().Release(enemy);
    }
}
