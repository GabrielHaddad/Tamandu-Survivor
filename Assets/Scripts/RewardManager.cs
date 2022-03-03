using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    PlayerLevel player;
    List<IAbility> allAbilities = new List<IAbility>();

    void Awake() 
    {
        player = FindObjectOfType<PlayerLevel>();
    }

    void OnEnable() 
    {
        InitializeAbilities();
    }

    void InitializeAbilities()
    {
        allAbilities.Add(new SprayAbility());
        allAbilities.Add(new ShootAbility());
        allAbilities.Add(new LightningAbility());
    }

    public List<IAbility> Return3RandomRewards()
    {
        List<IAbility> abilities = new List<IAbility>(allAbilities);
        List<IAbility> returnedAbilities = new List<IAbility>();

        for(int i = 0; i < 3; i++)
        {
            IAbility item = abilities[Random.Range(0, abilities.Count)];
            returnedAbilities.Add(item);
            abilities.Remove(item);
        }

        return returnedAbilities;
    }

    public void ActivateAbility(IAbility ability)
    {
        player.GetComponent<PlayerAbilityRunner>().SetActiveAbility(ability);
    }
}
