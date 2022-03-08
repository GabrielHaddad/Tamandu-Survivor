using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAbility : IAbility
{
    string abilityName = "Racket Ability";
    string abilityDescription = "Racket that damages an area of enemies";

    string resourcePrefabName = "Racket";
    int racketDamage = 10;
    int racketSpeed = 5;
    float rotationDuration = 2f;

    float racketRadius = 2f;

    float cooldownAbility = 3f;
    float cooldownTimer = 3f;

    public void Use(Transform playerTransform)
    {
        if (cooldownTimer <= 0.0f)
        {
            Debug.Log("Use Racket Ability");
            Debug.Log("Racket Cooldown: " + cooldownAbility);
            Debug.Log("Racket Damage: " + racketDamage);
            cooldownTimer = cooldownAbility;
            SpawnBullet(playerTransform);
            return;
        }

        cooldownTimer -= Time.deltaTime;
    }

    public void SpawnBullet(Transform playerTransform)
    {
        Vector3 positionAroundPlayer = RandomPositionOnCircunference(playerTransform.position);
        GameObject instance1 = GameObject.Instantiate(Resources.Load(resourcePrefabName, typeof(GameObject)), positionAroundPlayer, Quaternion.identity) as GameObject;
        GameObject instance2 = GameObject.Instantiate(Resources.Load(resourcePrefabName, typeof(GameObject)), positionAroundPlayer * -1, Quaternion.identity) as GameObject;

        instance1.GetComponent<RacketMovement>().SetDamage(racketDamage);
        instance1.GetComponent<RacketMovement>().SetSpeed(racketSpeed);
        instance1.GetComponent<RacketMovement>().SetRadius(racketRadius);
        instance1.GetComponent<RacketMovement>().SetDirection(1);
        instance1.GetComponent<RacketMovement>().SetDurationRotation(rotationDuration);

        instance2.GetComponent<RacketMovement>().SetDamage(racketDamage);
        instance2.GetComponent<RacketMovement>().SetSpeed(racketSpeed);
        instance2.GetComponent<RacketMovement>().SetRadius(racketRadius);
        instance2.GetComponent<RacketMovement>().SetDirection(-1);
        instance2.GetComponent<RacketMovement>().SetDurationRotation(rotationDuration);

    }

    Vector2 RandomPointOnUnitCircle(float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;

        return new Vector2(x, y);

    }

    public Vector3 RandomPositionOnCircunference(Vector3 playerPosition)
    {
        Vector2 randomInRadius = RandomPointOnUnitCircle(racketRadius);
        float xPos = playerPosition.x + randomInRadius.x;
        float zPos = playerPosition.z + randomInRadius.y;

        return new Vector3(xPos, playerPosition.y, zPos);
    }

    public void UpgradeAbility()
    {
        cooldownAbility -= 0.01f;
        racketDamage += 1;
        racketSpeed += 1;
        rotationDuration += 1;
        racketRadius += 1;
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
