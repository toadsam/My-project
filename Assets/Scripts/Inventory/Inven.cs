using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inven : MonoBehaviour
{
   //#region Singleton
    public static Inven Instance;   // �̱���ȭ ��Ŵ
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public delegate void OnSlotCountChange(int val);  //��������Ʈ ���� �����
    public OnSlotCountChange onSlotCountChange;  // ��������Ʈ  ����

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item>items = new List<Item>(); // �κ��丮�� ���� ������ �����

    private int slotCnt;  
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;  //value�� ���ؼ� �˾ƺ���
            onSlotCountChange.Invoke(slotCnt);
        }
    }
       

    // Start is called before the first frame update
    void Start()
    {
        SlotCnt = 4;  //������ �� �ִ� ���԰���
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)//�������� ������ ���Ժ��� ���� ���� �߰���
        {
            items.Add(_item);
            if(onChangeItem!= null)
            onChangeItem.Invoke(); // �����ϸ� �Լ� ȣ���϶�
            return true;
        }
        return false; 
    }

    public void RemoveItem(int _index)  //����ȣ�� �ִ� �������� �����ϴ� �޼���
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)  //�ʵ忡 �ִ� �������� �������� �޼���   
    {
        if(collision.CompareTag("FieldItem"))    // �ʵ��� �±۸� ���� �����ۿ� ��Ҵٸ�
        {
            FieldItems fieldItems = collision.GetComponent<FieldItems>(); // �ʵ�������� �Ӽ���������
            if(AddItem(fieldItems.GetItem()))  //�������� ���� �� �ִ��� ������ Ȯ���� �� ��������
                fieldItems.DestroyItem();  //�ʵ忡�ִ� �������� ���ֱ�
        }
    }
}
