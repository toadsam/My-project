using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenUi : MonoBehaviour
{
    Inven inven;  //�κ� Ŭ���� ���� 
    public GameObject inventoryUi;  // �κ�ui���� ������Ʈ �����
    bool activeInventory =false;  //ó������ fasle�� �����ϱ�
   


    public static Slot[] slots; // ������ ���� �迭 �����
    public Transform slotHolder;  // ������� ��ġ�� �������� ���ؼ� ����
    // Start is called before the first frame update
    void Start()
    {
        inven = Inven.Instance;  // �̱��� ��Ų �κ���������
        slots = slotHolder.GetComponentsInChildren<Slot>();  //�ڽĵ��� ������Ʈ�� ������ �� �� �ִ�.
        inven.onSlotCountChange += SlotChange;  // ���Կ��� �߰��ϰ� ���� �ִ� �޼��� ��������Ʈ�� ���
        inven.onChangeItem += RedrawSlotUI;    // ���Կ��� �����ϰ� ���� �� �ִ� �޼��� �����
        inventoryUi.SetActive(activeInventory); // ó������ �κ��丮 �ݱ�
    }

    private void SlotChange(int val)  //������ Ȱ��ȭ ��Ű���� �ʽ�Ű���� ���ϴ� �޼��� 
    {
       for(int i  = 0; i < slots.Length; i++) 
        {
            slots[i].slotnum = i;    //���Կ� ��ȣ ���̱�
            if (i < inven.SlotCnt)   // ������ ������ ���Ժ��� �۴ٸ�
                slots[i].GetComponent<Button>().interactable = true;  // Ȱ��ȭ ��Ű��
            else 
                slots[i].GetComponent<Button>().interactable = false;  // �ƴϸ� ��Ȱ��ȭ ��Ű��
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))  //��Ű�� ���ؼ� �κ��丮�� ����
        {
            activeInventory = !activeInventory;
            inventoryUi.SetActive(activeInventory);
        }
    }

    public void AddSlot()  // �����߰�
    {
        inven.SlotCnt++;
    }

    void RedrawSlotUI()   //�ٽ� ����� �޼���
    { 
        for(int i = 0; i < slots.Length;i++)
        {
            slots[i].RemoveSlot();  // ������ ���̸�ŭ ����
        }
        for(int i = 0;i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];  //������ �����ۿ� �κ� ������ ����
            slots[i].UpdateSlotUI();  //������Ʈ �ϱ�
        }
    }
   
}
