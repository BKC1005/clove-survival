using UnityEngine;

public class HpUpAbility : Ability
{
    public override void Use()
    {
        Clove clove = FindFirstObjectByType<Clove>();

        clove.maxhp += 5;
        clove.hp += 5;

        clove.HPBar.fillAmount = clove.hp / clove.maxhp;
    }
}