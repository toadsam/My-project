using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "TopDownController/Attacks/Default", order = 0)]  //스크렙터블 만들고 파일 이름과 순서 저장
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]   //헤더 이름정함
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;

    [Header("Knock Back Info")]  //해더 이름정함
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}