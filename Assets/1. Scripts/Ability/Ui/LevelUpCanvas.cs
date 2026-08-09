
using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUpCanvas : MonoBehaviour
{
    public AbilityName[] abilityNames = new AbilityName[5];
    public PickAbilityPanel[] pickAbilityPanels;
    void OnEnable()
    {
        
        // 생명 주기 함수 이해하기
        // 능력치 5개 중 3개 랜덤하게 뽑기

        //List<AbilityName> pickedAbilityNames = new List<AbilityName>();
        //pickedAbilityNames.AddRange(abilityNames);
        //pickedAbilityNames.RemoveAt(Random.Range(0, pickedAbilityNames.Count));
        //pickedAbilityNames.RemoveAt(Random.Range(0, pickedAbilityNames.Count));

        //for(int i = 0; i< pickAbilityPanels.Length; i++)
        //{
        //    pickAbilityPanels[i].SetAbilityName(pickedAbilityNames[i]);
        //}

        List<AbilityName> abilityNameList = new List<AbilityName>();
        abilityNameList.AddRange(abilityNames);
        for (int i = 0; i < 3; i++)
        {
            AbilityName aName = abilityNameList[Random.Range(0, abilityNameList.Count)];
            abilityNameList.Remove(aName);
            pickAbilityPanels[i].SetAbilityName(aName);
        }





        // 그 뽑은 능력치를 하위에 있는 픽어빌리티패널 컴포넌트에 각각으로 전달하기

        // 픽어빌리티패널 중 하나 선택 시 씬 상에 생성
    }
}
