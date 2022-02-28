using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : IAbility
{
    string abilityName = "Shoot Ability";
    string abilityDescription = "Shoot at the enenmy";

    public void Use()
    {
        Debug.Log("Use Shoot Ability");
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
