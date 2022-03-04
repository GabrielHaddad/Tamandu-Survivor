using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAbility : IAbility
{    
    string abilityName = "Lightning Ability";
    string abilityDescription = "Shoot bolts of ligtning around the player";

    string resourcePrefabName = "Lightning";

    float cooldownAbility = 3f;
    float cooldownTimer = 3f;
    float lightningRadius = 20;
    float lightningHeight = 5;

    public void Use(Transform playerTransform)
    {
        if (cooldownTimer <= 0.0f)
        {
            Debug.Log("Use Lightning Ability");
            Debug.Log("Ligtning Radius: " + lightningRadius);
            Debug.Log("Ligtning Cooldown: " + cooldownAbility);
            cooldownTimer = cooldownAbility;
            SpawnLightning(playerTransform);
            return;
        }

        cooldownTimer -= Time.deltaTime;
    }

    public void UpgradeAbility()
    {
        cooldownAbility -= 0.1f;
        lightningRadius += 1f;
    }

    void SpawnLightning(Transform playerTransform)
    {
        Vector2 randomPointInCircle = Random.insideUnitCircle * lightningRadius;
        Vector3 lightningInitialPos = new Vector3(playerTransform.position.x + randomPointInCircle.x, lightningHeight, playerTransform.position.z + randomPointInCircle.y);
        GameObject instance = GameObject.Instantiate(Resources.Load(resourcePrefabName, typeof(GameObject)), lightningInitialPos, Quaternion.identity) as GameObject;
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
