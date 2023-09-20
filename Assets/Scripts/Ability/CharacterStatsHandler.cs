using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour   //캐릭터 핸들러
{
    [SerializeField] private CharacterStats baseStats;   //기본 스탯
    public CharacterStats CurrentStates { get;  set; }  //현재 스탯
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();  //캐릭터 스탯을 담는 리스트 생성

    private void Awake()
    {
        UpdateCharacterStats();  //메서드 실행
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;  //처음에 attackSO값 초기화
        if (baseStats.attackSO != null)  // 만약 기본스텟값이 없다면 
        {
            attackSO = Instantiate(baseStats.attackSO);  // 기본값 생성
        }

        CurrentStates = new CharacterStats { attackSO = attackSO };  //현재 상태에 attackSO넣기
        // TODO
        CurrentStates.statsChangeType = baseStats.statsChangeType;   //전부타 현재의 값으로 넣어주기
        CurrentStates.maxHealth = baseStats.maxHealth;
        CurrentStates.speed = baseStats.speed;
        //Debug.Log(CurrentStates.speed);

    }
}