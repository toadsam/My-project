using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler //���� ��� ���� ������  //�����͸� �� �� ȣ�� �� �� �ֵ��� �ϴ� �̺�Ʈ�� ���� ���ؼ� ��ӹ���
{
    public int slotnum;
    public Item item;  // ������ Ŭ���� �����
    public Image itemIcon;  // �̹��� ���� -> ���Կ� �ִ� �̹��� ���� ����

    public void UpdateSlotUI()  // UI�� ������Ʈ �ϴ� �޼���
    {
        itemIcon.sprite = item.itemImage;    //  �������� �̹��� �ֱ�
        itemIcon.gameObject.SetActive(true); // �������� �̹��� Ű��
    }

    public void RemoveSlot()  //���Ծ����� ����
    {  
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)  // �����͸� �� �� ȣ���ϴ� �޼���
    {
        bool isUse = item.Use();
        if(isUse) 
        {
            Inven.Instance.RemoveItem(slotnum);  // 
        }
    }
}
