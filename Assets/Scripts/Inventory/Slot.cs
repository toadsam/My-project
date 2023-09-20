using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler //슬록 장비 관리 아이템  //포인터를 뗄 때 호출 할 수 있도록 하는 이벤트를 쓰기 위해서 상속받음
{
    public int slotnum;
    public Item item;  // 아이템 클래스 만들기
    public Image itemIcon;  // 이미지 선언 -> 슬롯에 있는 이미지 받을 예정

    public void UpdateSlotUI()  // UI로 업데이트 하는 메서드
    {
        itemIcon.sprite = item.itemImage;    //  아이템의 이미지 넣기
        itemIcon.gameObject.SetActive(true); // 아이템의 이미지 키기
    }

    public void RemoveSlot()  //슬롯아이템 삭제
    {  
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)  // 포인터를 뗄 떄 호출하는 메세드
    {
        bool isUse = item.Use();
        if(isUse) 
        {
            Inven.Instance.RemoveItem(slotnum);  // 
        }
    }
}
