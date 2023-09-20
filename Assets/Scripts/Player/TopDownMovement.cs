using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    public Animator ani;
    private CharacterStatsHandler _stats;
    
    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _stats = GetComponent<CharacterStatsHandler>(); // 캐릭터 스탯조절 추가
        _rigidbody = GetComponent<Rigidbody2D>();
       
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovment(Vector2 direction)
    {

        direction = direction * _stats.CurrentStates.speed;

        _rigidbody.velocity = direction;
       // Debug.Log(_rigidbody.velocity);
        //if (_rigidbody.velocity.x > 1.0)
        //{
        //    ani.SetBool("isRight", true);
        //}
        //else
        //{
        //    ani.SetBool("isRight", false);
        //    Debug.Log(_rigidbody.velocity.x);
        //}
    }
}