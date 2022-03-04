using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayAbility : IAbility
{
    string abilityName = "Spray Ability";
    string abilityDescription = "Spray that damages an area of enemies";

    public void Use(Transform playerTransform)
    {
        Debug.Log("Use Spray Ability");
        return;
    }

    public void UpgradeAbility()
    {
        
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
