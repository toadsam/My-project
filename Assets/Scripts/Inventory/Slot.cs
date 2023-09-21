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
    AgainItemUi againItemUi;



    public void Awake()
    {
       
        //아이템을 사용한다는 델리게이트 받기
                                                  // 객체를 초기화 시켜줘야함. playerWeapon =  GetComponent<SpriteRenderer>(); -> 즉 플레이어의 무기를 여기로 가져올 수 있어야한다.
                                                  //AgainItemUi.transform.SetSiblingIndex(0);
    }
     void Start()
    {
        againItemUi = AgainItemUi.Instance;
        //againItemUi.yesAgainItem += AgainItemYes;
    }
    void Update()
    {

        if (againItemUi.yesAgainItem == true)
        {
            AgainItemYes();
            againItemUi.yesAgainItem = !againItemUi.yesAgainItem;
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
        againItemUi.isAgainItem = true;  //패널 활성화 시킴
        
        //bool isUse = item.Use();
        //if (isUse)
        //{

        //    if (item.itemType == 0)
        //    {

        //        Debug.Log("여기 억인");
        //        Inven.Instance.playerWeapon.sprite = item.itemImage;
        //        //이제 여기다가 플레이어의 이미지를 받아서 교체를 해준다
        //    }
        //    Inven.Instance.RemoveItem(slotnum);  // 
        //}
        //Debug.Log("이게 문제니?");
        // AgainItemUi.SetActive(true);

        // AgainItemYes();
    }
   public void AgainItemYes()
    {
        bool isUse = item.Use();
        if (isUse)
        {

            if (item.itemType == 0)
            {

                Debug.Log("여기 억인");
                Inven.Instance.playerWeapon.sprite = item.itemImage;
                //이제 여기다가 플레이어의 이미지를 받아서 교체를 해준다
            }
            Inven.Instance.RemoveItem(slotnum);  // 
        }
    }

    
}
