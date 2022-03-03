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
            StartCoroutine(ability.Use());
        }
    }

    public void SetActiveAbility(IAbility ability)
    {
        activeAbilities.Add(ability);
    }

}
