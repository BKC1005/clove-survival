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
        this.abilityName = abilityName;
        Ability ability;
        ability = AbilityManager.Instance.GetAbility(abilityName);

        ablitytitle.text = ability.title;
        thum.sprite = ability.thum;
    }

    public void OnclikedPanel()
    {
        Debug.Log("선택한 이름:" + abilityName);
        Ability ability = AbilityManager.Instance.GetAbility(abilityName);
        Debug.Log("가져온 능력:" + ability);
        LevelUpCanvas canvas = GetComponentInParent<LevelUpCanvas>();
        Debug.Log("LevelUpCanvas:" + canvas);
        canvas.PickedAbility(ability);
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
