using UnityEngine;

public class MeddleAbility : Ability
{
    public int chance;
    public override string GetDesc()
    {
        string temp;
        temp = string.Format(desc, "", GetChance(level + 1));
        return temp;
    }

    public int GetChance(int lv)
    {
        return chance + lv - 1;
    }

    public bool Check()
    {
        int random = Random.Range(0, 100);
        if (random < GetChance(level))
        {
            return true;
        }
        return false;
    }

    public override void Use()
    {
        level++;
    }
}
