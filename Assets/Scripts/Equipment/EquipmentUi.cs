using System.Collections;
using System.Collections.Generic;
using Unity.IO.Archive;
using UnityEngine;

public class EquipmentUi : MonoBehaviour
{
    public GameObject equipmentUi;  // �κ�ui���� ������Ʈ �����
    bool activeEquipment = false;  //ó������ fasle�� �����ϱ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  //eŰ�� ���ؼ� �κ��丮�� ����
        {
            activeEquipment = !activeEquipment;
            equipmentUi.SetActive(activeEquipment);
        }
    }
   
}
