using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAbility : IAbility
{
    string abilityName = "Lightning Ability";
    string abilityDescription = "Shoot bolts of ligtning around the player";

    float lightningDelay = 1f;

    bool canUse = true;

    public IEnumerator Use()
    {
        if (!canUse) yield break;

        canUse = false;

        Debug.Log("Use Lightning Ability");
        yield return new WaitForSeconds(lightningDelay);

        canUse = true;
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
