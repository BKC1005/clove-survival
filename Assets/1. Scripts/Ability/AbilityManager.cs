using UnityEditor.Playables;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance;
    public Ability[] abilities;

    private void Awake()
    {
        Instance = this;
        abilities = GetComponentsInChildren<Ability>();
    }

    private void Start()
    {
        Debug.Log(abilities[1].abilityName);
    }

    public Ability GetAbility(AbilityName abilityName)
    {
        for (int i = 0; i < AbilityManager.Instance.abilities.Length; i++)
        {
            if (abilityName == AbilityManager.Instance.abilities[i].abilityName)
            {
                return abilities[i];
            }

            
        }

        return null;
    }
}
