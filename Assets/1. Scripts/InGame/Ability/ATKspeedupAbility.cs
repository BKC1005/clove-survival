using Unity.VisualScripting;
using UnityEngine;

public class ATKspeedupAbility : Ability
{
    public float multiValue = 0.1f;
    public override string GetDesc()
    {
        float mV = GetMultiValue(level + 1);
        string temp = string.Format(desc, mV * 100);
        return temp;
    }
    public float GetMultiValue(int lv)
    {
        return lv* multiValue;
    }
    public override void Use()
    {
        Clove clove = FindFirstObjectByType<Clove>();

        clove.atkspeed *= 1 - multiValue;
    }
}
