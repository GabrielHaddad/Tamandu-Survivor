using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Player health")]
    [SerializeField] int maxHealth = 100;
    int currentHealth;

    void Start() 
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //TakeDamage(other.gameObject.GetComponent<Enemy>().Damage);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            //Kill Player
            Debug.Log("Died");
        }
    }

}
