using UnityEngine;

public interface IAbility
{
    void Use(Transform playerTransform);
    void UpgradeAbility();
    public string GetAbilityName();

    public string GetAbilityDescription();
}