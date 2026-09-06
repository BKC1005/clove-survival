
using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUpCanvas : MonoBehaviour
{
    public AbilityName[] abilityNames = new AbilityName[5];
    public PickAbilityPanel[] pickAbilityPanels;
    public Ability pickAbility;
    public TMP_Text descText;
    void OnEnable()
    {

        // 생명 주기 함수 이해하기
        // 능력치 5개 중 3개 랜덤하게 뽑기
        Time.timeScale = 0;
        pickAbility = null;
        descText.text = "능력설명";
        List<AbilityName> abilityNameList = new List<AbilityName>();
        abilityNameList.AddRange(abilityNames);
        for (int i = 0; i < 3; i++)
        {
            AbilityName aName = abilityNameList[Random.Range(0, abilityNameList.Count)];
            Debug.Log($"AbilityName {aName} i {i}");
            abilityNameList.Remove(aName);
            pickAbilityPanels[i].SetAbilityName(aName);
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1; 
    }
    public void PickedAbility(Ability ability)
    {
        descText.text = ability.GetDesc();
        pickAbility = ability;
    }
    public void ConfirmAbility()
    {
        if (pickAbility == null) return;
        pickAbility.Levelup();
        gameObject.SetActive(false);
    }
}
