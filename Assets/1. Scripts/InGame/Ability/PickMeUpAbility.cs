using UnityEngine;

public class PickMeUpAbility : Ability
{
    public int hitCount;
    public int hitLimit;

    public override string GetDesc()
    {
        string temp;
        temp = string.Format(desc, "", GetHitLimit(level + 1));
        return temp;
    }

    public int GetHitLimit(int lv)
    {
        return hitLimit - lv;
    }

    public void Hit()
    {
        hitCount++;

        if (hitCount >= GetHitLimit(level))
        {
            Clove clove = FindFirstObjectByType<Clove>();

            clove.hp += 1;

            if (clove.hp > clove.maxhp)
            {
                clove.hp = clove.maxhp;
            }

            clove.HPBar.fillAmount = clove.hp / clove.maxhp;

            hitCount = 0;
        }
    }

    public override void Use()
    {
        level++;
    }
}