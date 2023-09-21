using System.Collections;
using System.Collections.Generic;
using Unity.IO.Archive;
using UnityEngine;

public class EquipmentUi : MonoBehaviour
{
    public GameObject equipmentUi;  // 인벤ui담을 오브젝트 만들기
    bool activeEquipment = false;  //처음에는 fasle로 설정하기
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  //e키를 통해서 인벤토리를 관리
        {
            activeEquipment = !activeEquipment;
            equipmentUi.SetActive(activeEquipment);
        }
    }
   
}
