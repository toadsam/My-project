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

    public delegate void OnSlotCountChange(int val);  //델리게이트 형식 만들기
    public OnSlotCountChange onSlotCountChange;  // 델리게이트  만듬

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item>items = new List<Item>(); // 인벤토리에 담을 아이템 만들기

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
