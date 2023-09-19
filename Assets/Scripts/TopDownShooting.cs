using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _contoller;  //컨트롤러 받아옴
          
    [SerializeField] private Transform projectileSpawnPosition;   //스폰위치 
    private Vector2 _aimDirection = Vector2.right;   // 방향은 오른쪽
    private ProjectileManager _projectileManager;
    public GameObject testPrefab;
    private void Awake()
    {
        _contoller = GetComponent<TopDownCharacterController>();  //컨트롤러 가져옴
    }

    // Start is called before the first frame update
    void Start()
    { 
        _contoller.OnAttackEvent += OnShoot;   //각각 이벤트에 메서드 추가
        _contoller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)  //새로운 방향 저장
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;


        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = UnityEngine.Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
    }

    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(
                projectileSpawnPosition.position,
                RotateVector2(_aimDirection, angle),
                rangedAttackData
                );
    }
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}