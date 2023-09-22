using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType   //캐릭터 능력치 만듬
{
    Add,
    Multiple,
    Override,
} 

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public int money;
    public int level;
    public AttackSO attackSO;
}