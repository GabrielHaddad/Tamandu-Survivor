using UnityEngine;

public class ShootAbility : IAbility
{
    string abilityName = "Shoot Ability";
    string abilityDescription = "Shoot at the enenmy";

    string resourcePrefabName = "Bullet";
    int bulletDamage = 10;
    int bulletSpeed = 10;

    float cooldownAbility = 1f;
    float cooldownTimer = 1f;

    public void Use(Transform playerTransform)
    {
        if (cooldownTimer <= 0.0f)
        {
            Debug.Log("Use Shoot Ability");
            Debug.Log("Shoot Cooldown: " + cooldownAbility);
            Debug.Log("Shoot Damage: " + bulletDamage);
            cooldownTimer = cooldownAbility;
            SpawnBullet(playerTransform);
            return;
        }

        cooldownTimer -= Time.deltaTime;
    }

    public void SpawnBullet(Transform playerTransform)
    {
        Vector3 gunPosition = playerTransform.GetChild(0).transform.position;
        GameObject instance = GameObject.Instantiate(Resources.Load(resourcePrefabName, typeof(GameObject)), gunPosition, Quaternion.identity) as GameObject;

        instance.GetComponent<Bullet>().SetDamage(bulletDamage);
        instance.GetComponent<Bullet>().SetSpeed(bulletSpeed);
    }

    public void UpgradeAbility()
    {
        cooldownAbility -= 0.01f;
        bulletDamage += 1;
        bulletSpeed += 1;
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
