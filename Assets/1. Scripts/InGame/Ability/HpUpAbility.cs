using JetBrains.Annotations;
using UnityEngine;

public class HpUpAbility : Ability
{
    public int addHp;
    public override string GetDesc()
    {        
        string temp;

        temp = string.Format(desc, "", GetAddHp(level + 1));


        return temp;
    }
    public int GetAddHp(int lv)
    {
        return lv * addHp;
    }
    public override void Use()
    {
        Clove clove = FindFirstObjectByType<Clove>();

        clove.maxhp += 5;
        clove.hp += 5;

        clove.HPBar.fillAmount = clove.hp / clove.maxhp;
    }
}