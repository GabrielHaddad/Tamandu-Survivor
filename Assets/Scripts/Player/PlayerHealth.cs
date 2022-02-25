using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Player health")]
    [SerializeField] int maxHealth = 100;
    int currentHealth;
    bool isDead;
    LevelLoader levelLoader;

    void Awake() 
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    void Start() 
    {
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

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(other.gameObject.GetComponent<EnemyBehavior>().Damage);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
        {
            levelLoader.RestartLevel();
            isDead = true;
        }
    }

}
