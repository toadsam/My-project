using System;
using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;  //매게변수를 AttackSO로 하는 액션이벤트 만들기

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }


    protected CharacterStatsHandler Stats { get; private set; }
    protected virtual void Awake()
    {
        Debug.Log("잉번");
        Stats = GetComponent<CharacterStatsHandler>();
    }
    protected virtual void update()
    {
        Debug.Log("잉번");
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
            Debug.Log("나비엉있어번");
            return;
        }


        if (_timeSinceLastAttack <= Stats.CurrentStates.attackSO.delay)
        {
            Debug.Log("1번");
            _timeSinceLastAttack += Time.deltaTime;
        }


        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStates.attackSO.delay)
        {
            _timeSinceLastAttack = 0;
            Debug.Log("2번");
            CallAttackEvent(Stats.CurrentStates.attackSO);
        }
    }
    public void CallAttackEvent(AttackSO attackSO)
    {
        
        OnAttackEvent?.Invoke(attackSO);
    }
}