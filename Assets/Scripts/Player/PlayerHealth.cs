using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Player health")]
    [SerializeField] int maxHealth = 100;

    [Tooltip("Hit Particle")]
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] float hitDelay = 1f;
    int currentHealth;
    bool isDead;
    LevelLoader levelLoader;
    bool canHit = true;

    public event Action onHealthChange;


    void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        currentHealth = maxHealth;
    }

    public void SetIsDead(bool value)
    {
        isDead = value;
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    public int GetFullHealth()
    {
        return maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && canHit)
        {
            TakeDamage(other.gameObject.GetComponent<EnemyBehavior>().Damage);
            CameraShake.Instance.ShakeCamera(10f, 0.1f);
            PlayhitEffect();
            StartCoroutine(HitCooldown());
        }
    }

    IEnumerator HitCooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(hitDelay);
        canHit = true;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (onHealthChange != null)
        {
            onHealthChange();
        }

        if (currentHealth <= 0 && !isDead)
        {
            levelLoader.RestartLevel();
            isDead = true;
        }
    }

    void PlayhitEffect()
    {
        if (hitParticle != null)
        {
            ParticleSystem instance = Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

}
