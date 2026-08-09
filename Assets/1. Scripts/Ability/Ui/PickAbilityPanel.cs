using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickAbilityPanel : MonoBehaviour
{
    public AbilityName abilityName;
    public TMP_Text ablitytitle;
    public Image thum;
    public void SetAbilityName(AbilityName abilityName)
    {
        abilityName = AbilityName.PickMeup;
        this.abilityName = abilityName;
        Ability ability;
        ability = AbilityManager.Instance.GetAbility(abilityName);

        ablitytitle.text = ability.title;
        thum.sprite = ability.thum;
    }

    public void OnclikedPanel()
    {
        
    }
}


public enum AbilityName
{
    PickMeup,
    HpUp,
    Meddle,
    Ruse,
    ATKspeed
}
