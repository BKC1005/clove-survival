using UnityEngine;

public class Ability : MonoBehaviour
{
    // 모든 능력의 부모 클래스

    public AbilityName abilityName;
    public string title;
    public Sprite thum;
    public string desc;
    public virtual void Use()
    {
    }
}

