using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityRunner : MonoBehaviour
{
    [SerializeField] List<IAbility> activeAbilities = new List<IAbility>();

    void Update() 
    {
        UseAbility();
    }

    public void UseAbility()
    {
        foreach(IAbility ability in activeAbilities)
        {
            ability.Use(transform);
        }
    }

    public void SetActiveAbility(IAbility ability)
    {
        IAbility foundAbility = activeAbilities.Find((activeAbility) => activeAbility == ability);

        if (foundAbility != null)
        {
            Debug.Log("Found duplicate");
            ability.UpgradeAbility();
        }
        else
        {
            activeAbilities.Add(ability);
        }
    }
}
