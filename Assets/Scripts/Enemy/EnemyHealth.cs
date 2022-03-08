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
        TakeDamage(other.GetComponent<Bullet>().Damage);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(other.GetComponent<Bullet>().Damage);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Racket"))
        {
            TakeDamage(other.GetComponent<RacketMovement>().Damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        enemy.ReleaseEnemy();
        PlayDeathEffect();
        FindObjectOfType<PlayerLevel>().GainExperience(experienceValue);
        CameraShake.Instance.ShakeCamera(2f, 0.1f);
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
