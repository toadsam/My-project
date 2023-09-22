using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inven : MonoBehaviour
{
   //#region Singleton
    public static Inven Instance;   // 싱글톤화 시킴
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public delegate void OnSlotCountChange(int val);   //델리게이트 형식 만들기
    public OnSlotCountChange onSlotCountChange;       // 델리게이트  만듬

    public SpriteRenderer playerWeapon;  //플레이어의 무기를 바꾸기 위함
    public SpriteRenderer playerHat;  //플레이어의 모자를 바꾸기 위함

    public delegate  void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item>items = new List<Item>(); // 인벤토리에 담을 아이템 만들기
    public List<Item> equipmentItems = new List<Item>();  //장비창에 담을 아이템 구현

    private int slotCnt;  
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;  //value에 대해서 알아보기
            onSlotCountChange.Invoke(slotCnt);
        }
    }
       

    // Start is called before the first frame update
    void Start()
    {
        SlotCnt = 4;  //저장할 수 있는 슬롯개수
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)//아이템의 갯수가 슬롯보다 작을 때만 추가함
        {
            items.Add(_item);
            if(onChangeItem!= null)
            onChangeItem.Invoke(); // 성공하면 함수 호출하라
            return true;
        }
        return false; 
    }

    public void RemoveItem(int _index)  //각번호에 있는 아이템을 제거하는 메서드
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }
    public bool AddEquipmentItem(int _index)
    {
        int isSameType = 0;
        int sameTypeNum = 0;
        for(int i = 0; i < equipmentItems.Count;i++)
        {
            if (equipmentItems[i].itemType == items[_index].itemType)  //반복문 빠져나오는 거알아보기
            {
                sameTypeNum = i;
                isSameType++;
            }
        }
        if (isSameType > 0) //이미 같은 타입의 장비가 있다면 삭제 후 착용
        {
            AddItem(equipmentItems[sameTypeNum]);  //인벤토리 창에 넣고
            equipmentItems.RemoveAt(sameTypeNum);  //장비창에서 삭제    
            equipmentItems.Add(items[_index]);             //장비창에서 추가하고
            items.Remove(items[_index]);
            onChangeItem.Invoke();
            return true;
        }
        else
        {
            equipmentItems.Add(items[_index]);//기존에 착용한거 삭제하기
            items.Remove(items[_index]);
            onChangeItem.Invoke();
            return true;
        }
      
    }


    private void OnTriggerEnter2D(Collider2D collision)  //필드에 있는 아이템을 가져오는 메서드   
    {
        if(collision.CompareTag("FieldItem"))    // 필드라는 태글르 가진 아이템에 닿았다면
        {
            FieldItems fieldItems = collision.GetComponent<FieldItems>(); // 필드아이템의 속성가져오기
            if(AddItem(fieldItems.GetItem()))  //아이템을 받을 수 있는지 조건을 확인한 후 가져오고
                fieldItems.DestroyItem();  //필드에있는 아이템은 없애기
        }
    }
}
