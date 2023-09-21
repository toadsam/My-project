using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenUi : MonoBehaviour
{
    Inven inven;  //인벤 클래스 생성 
    public GameObject inventoryUi;  // 인벤ui담을 오브젝트 만들기
    bool activeInventory =false;  //처음에는 fasle로 설정하기
   


    public static Slot[] slots; // 슬록을 담을 배열 만들기
    public Transform slotHolder;  // 슬룻들의 위치를 가져오기 위해서 선언
    // Start is called before the first frame update
    void Start()
    {
        inven = Inven.Instance;  // 싱글톤 시킨 인벤가져오기
        slots = slotHolder.GetComponentsInChildren<Slot>();  //자식들의 컴포넌트를 가지고 올 수 있다.
        inven.onSlotCountChange += SlotChange;  // 슬롯에서 추가하고 뺄수 있는 메서드 델리게이트에 담기
        inven.onChangeItem += RedrawSlotUI;    // 슬롯에서 제거하고 없앨 수 있는 메서드 만들기
        inventoryUi.SetActive(activeInventory); // 처음에는 인벤토리 닫기
    }

    private void SlotChange(int val)  //슬롯을 활성화 시키는지 않시키는지 결하는 메서드 
    {
       for(int i  = 0; i < slots.Length; i++) 
        {
            slots[i].slotnum = i;    //슬롯에 번호 붙이기
            if (i < inven.SlotCnt)   // 슬롯이 열었던 슬롯보다 작다면
                slots[i].GetComponent<Button>().interactable = true;  // 활성화 시키기
            else 
                slots[i].GetComponent<Button>().interactable = false;  // 아니면 비활성화 시키기
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))  //ㅣ키를 통해서 인벤토리를 관리
        {
            activeInventory = !activeInventory;
            inventoryUi.SetActive(activeInventory);
        }
    }

    public void AddSlot()  // 슬롯추가
    {
        inven.SlotCnt++;
    }

    void RedrawSlotUI()   //다시 만드는 메서드
    { 
        for(int i = 0; i < slots.Length;i++)
        {
            slots[i].RemoveSlot();  // 슬롯의 길이만큼 삭제
        }
        for(int i = 0;i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];  //슬롯의 아이템에 인벤 아이템 저장
            slots[i].UpdateSlotUI();  //업데이트 하기
        }
    }
   
}
