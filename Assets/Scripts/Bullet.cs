using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    int speed;
    int damage;
    public int Damage => damage;

    Transform enemyTarget;

    public void SetDamage(int damageNumber)
    {
        damage = damageNumber;
    }

    public void SetSpeed(int speedNumber)
    {
        speed = speedNumber;
    }

    void Update()
    {
        FindClosestTarget();
        if (enemyTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyTarget.position, Time.deltaTime * speed);
        }
    }

    void FindClosestTarget()
    {
        EnemyBehavior[] enemies = GameObject.FindObjectsOfType<EnemyBehavior>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (EnemyBehavior enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                maxDistance = targetDistance;
                closestTarget = enemy.transform;
            }
        }

        enemyTarget = closestTarget;
    }
}
