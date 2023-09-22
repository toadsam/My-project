using JetBrains.Annotations;
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

    public delegate void OnSlotCountChange(int val);   //��������Ʈ ���� �����
    public OnSlotCountChange onSlotCountChange;       // ��������Ʈ  ����

    public SpriteRenderer playerWeapon;  //�÷��̾��� ���⸦ �ٲٱ� ����
    public SpriteRenderer playerHat;  //�÷��̾��� ���ڸ� �ٲٱ� ����

    public delegate  void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item>items = new List<Item>(); // �κ��丮�� ���� ������ �����
    public List<Item> equipmentItems = new List<Item>();  //���â�� ���� ������ ����

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
    public bool AddEquipmentItem(int _index)
    {
        int isSameType = 0;
        int sameTypeNum = 0;
        for(int i = 0; i < equipmentItems.Count;i++)
        {
            if (equipmentItems[i].itemType == items[_index].itemType)  //�ݺ��� ���������� �ž˾ƺ���
            {
                sameTypeNum = i;
                isSameType++;
            }
        }
        if (isSameType > 0) //�̹� ���� Ÿ���� ��� �ִٸ� ���� �� ����
        {
            AddItem(equipmentItems[sameTypeNum]);  //�κ��丮 â�� �ְ�
            equipmentItems.RemoveAt(sameTypeNum);  //���â���� ����    
            equipmentItems.Add(items[_index]);             //���â���� �߰��ϰ�
            items.Remove(items[_index]);
            onChangeItem.Invoke();
            return true;
        }
        else
        {
            equipmentItems.Add(items[_index]);//������ �����Ѱ� �����ϱ�
            items.Remove(items[_index]);
            onChangeItem.Invoke();
            return true;
        }
      
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
