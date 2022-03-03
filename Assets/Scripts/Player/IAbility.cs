using System.Collections;

public interface IAbility
{
    IEnumerator Use();
    public string GetAbilityName();

    public string GetAbilityDescription();
}