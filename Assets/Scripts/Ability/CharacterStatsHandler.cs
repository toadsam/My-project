using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour   //ĳ���� �ڵ鷯
{
    [SerializeField] private CharacterStats baseStats;   //�⺻ ����
    public CharacterStats CurrentStates { get;  set; }  //���� ����
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();  //ĳ���� ������ ��� ����Ʈ ����

    private void Awake()
    {
        UpdateCharacterStats();  //�޼��� ����
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;  //ó���� attackSO�� �ʱ�ȭ
        if (baseStats.attackSO != null)  // ���� �⺻���ݰ��� ���ٸ� 
        {
            attackSO = Instantiate(baseStats.attackSO);  // �⺻�� ����
        }

        CurrentStates = new CharacterStats { attackSO = attackSO };  //���� ���¿� attackSO�ֱ�
        // TODO
        CurrentStates.statsChangeType = baseStats.statsChangeType;   //����Ÿ ������ ������ �־��ֱ�
        CurrentStates.maxHealth = baseStats.maxHealth;
        CurrentStates.speed = baseStats.speed;
        //Debug.Log(CurrentStates.speed);

    }
}