using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAreaAbility : IAbility
{
    string abilityName = "Damage Area Ability";
    string abilityDescription = "Damage in Area Per Seconds";

    float cooldownAbility = 3f;
    float cooldownTimer = 3f;
    float damageRadius = 5;
    int damage = 10;

    LayerMask enemyLayer = LayerMask.GetMask("Enemy");

    public void Use(Transform playerTransform)
    {
        if (cooldownTimer <= 0.0f)
        {
            Debug.Log("Damage Area Ability");
            Debug.Log("Damage Radius: " + damageRadius);
            Debug.Log("Damage Cooldown: " + cooldownAbility);
            cooldownTimer = cooldownAbility;
            DamageArea(playerTransform);
            return;
        }

        cooldownTimer -= Time.deltaTime;
    }

    public void UpgradeAbility()
    {
        cooldownAbility -= 0.1f;
        damage += 1;
        damageRadius += 1;
    }

    void DamageArea(Transform playerTransform)
    {
        Collider[] enemies =  Physics.OverlapSphere(playerTransform.position, damageRadius, enemyLayer);

        foreach(Collider enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    public string GetAbilityName()
    {
        return abilityName;
    }

    public string GetAbilityDescription()
    {
        return abilityDescription;
    }
}
