using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour, IPointerUpHandler //슬록 장비 관리 아이템  //포인터를 뗄 때 호출 할 수 있도록 하는 이벤트를 쓰기 위해서 상속받음
{
    public int slotnum;
    public Item item;  // 아이템 클래스 만들기
    public Image itemIcon;  // 이미지 선언 -> 슬롯에 있는 이미지 받을 예정
                            // public AgainItemUi againItemUi;
                            //public GameObject a;
    static int eachNum;


    public void Start()
    {
      //  AgainItemUi.Instance.yesAgainItem += AgainItemYes;
    }

    private void Update()
    {
        if (AgainItemUi.Instance.isYesBtn)
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
        eachNum = this.slotnum;
        AgainItemUi.Instance.AgainItemUiPenal.SetActive(true);
        
    }
    public void AgainItemYes()
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

            else Inven.Instance.RemoveItem(slotnum);  // 
            
        }
    }

    
}
