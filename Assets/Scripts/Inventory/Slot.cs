using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour, IPointerUpHandler //슬록 장비 관리 아이템  //포인터를 뗄 때 호출 할 수 있도록 하는 이벤트를 쓰기 위해서 상속받음
{
    public int slotnum; //각 슬롯객체의 번호 지정
    public Item item;   // 아이템 클래스 생성
    public Image itemIcon; //아이템 이미지 생성
                            
    static int eachNum;  // 각 객체마다 고유의 번호를 주기위해서 만듬 


    

    private void Update()
    {
        if (AgainItemUi.Instance.isYesBtn)            //장비재확인창에서 확인버튼을 누르면 slots[eachNum]만 실행
        {
            InvenUi.slots[eachNum].AgainItemYes();
            AgainItemUi.Instance.isYesBtn = false;
        }
    }


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
        eachNum = this.slotnum;  // 이 객체에만 사용하기 위해서 고유의 번호를 부여함
        AgainItemUi.Instance.AgainItemUiPenal.SetActive(true);  //다시하기 버튼 활성화시키기
        
    }
    public void AgainItemYes()  //확인버튼을 누르면 아이템의 유형별로 결정하는 메서드
    {
        bool isUse = item.Use();
        if (isUse)
        {

            if (item.itemType == ItemType.AttakEquipment)
            {            
                Inven.Instance.playerWeapon.sprite = item.itemImage;
                Inven.Instance.AddEquipmentItem(slotnum);
                //이제 여기다가 플레이어의 이미지를 받아서 교체를 해준다

            }
            else if (item.itemType == ItemType.HatEquipment)
            {
                Inven.Instance.playerHat.sprite = item.itemImage;
                Inven.Instance.AddEquipmentItem(slotnum);
            }

            else Inven.Instance.RemoveItem(slotnum);   
            
        }
    }

    
}
