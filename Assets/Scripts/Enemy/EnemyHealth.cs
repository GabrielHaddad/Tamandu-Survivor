using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Enemy health")]
    [SerializeField] int maxHealth = 10;

    [SerializeField] int experienceValue = 100;

    [Tooltip("Death Particle")]
    [SerializeField] ParticleSystem deathParticle;

    int currentHealth;
    EnemyBehavior enemy;

    void Awake() 
    {
        enemy = GetComponent<EnemyBehavior>();
    }

    void OnEnable() 
    {
        currentHealth = maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(other.GetComponent<Bullet>().Damage, other);
    }

    void TakeDamage(int damage, GameObject other)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            KillEnemy(other);
        }
    }

    void KillEnemy(GameObject other)
    {
        enemy.ReleaseEnemy();
        PlayDeathEffect();
        other.gameObject.GetComponentInParent<PlayerLevel>().GainExperience(experienceValue);
        CameraShake.Instance.ShakeCamera(5f, 0.1f);
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
