using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Enemy health")]
    [SerializeField] int maxHealth = 10;

    [Tooltip("Death Particle")]
    [SerializeField] ParticleSystem deathParticle;

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
        TakeDamage(other.GetComponent<Bullet>().Damage);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        enemy.GetPool().Release(enemy);
        PlayDeathEffect();
    }

    void PlayDeathEffect()
    {
        if (deathParticle != null)
        {
            ParticleSystem instance = Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}