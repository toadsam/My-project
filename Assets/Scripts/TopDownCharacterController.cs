using System;
using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;  //�ŰԺ����� AttackSO�� �ϴ� �׼��̺�Ʈ �����

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }


    protected CharacterStatsHandler Stats { get; private set; }
    protected virtual void Awake()
    {
        Debug.Log("�׹�");
        Stats = GetComponent<CharacterStatsHandler>();
    }
    protected virtual void update()
    {
        Debug.Log("�׹�");
        HandleAttackDelay();
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);

    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    private void HandleAttackDelay()
    {
        if (Stats.CurrentStates.attackSO == null)
        {
            Debug.Log("������־��");
            return;
        }


        if (_timeSinceLastAttack <= Stats.CurrentStates.attackSO.delay)
        {
            Debug.Log("1��");
            _timeSinceLastAttack += Time.deltaTime;
        }


        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStates.attackSO.delay)
        {
            _timeSinceLastAttack = 0;
            Debug.Log("2��");
            CallAttackEvent(Stats.CurrentStates.attackSO);
        }
    }
    public void CallAttackEvent(AttackSO attackSO)
    {
        
        OnAttackEvent?.Invoke(attackSO);
    }
}