using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;   //메서드 추가
    }

    public void OnAim(Vector2 newAimDirection)  // 벡터의 값을 받아온다 
    {
        RotateArm(newAimDirection);  //메서드실행
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  //아크첸젠트의 각도를 곱해서 라디안의 값으오 만들어줌

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f; //ㅈ
        characterRenderer.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}