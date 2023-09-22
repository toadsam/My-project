using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour, IPointerUpHandler //���� ��� ���� ������  //�����͸� �� �� ȣ�� �� �� �ֵ��� �ϴ� �̺�Ʈ�� ���� ���ؼ� ��ӹ���
{
    public int slotnum; //�� ���԰�ü�� ��ȣ ����
    public Item item;   // ������ Ŭ���� ����
    public Image itemIcon; //������ �̹��� ����
                            
    static int eachNum;  // �� ��ü���� ������ ��ȣ�� �ֱ����ؼ� ���� 


    

    private void Update()
    {
        if (AgainItemUi.Instance.isYesBtn)            //�����Ȯ��â���� Ȯ�ι�ư�� ������ slots[eachNum]�� ����
        {
            InvenUi.slots[eachNum].AgainItemYes();
            AgainItemUi.Instance.isYesBtn = false;
        }
    }


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
        eachNum = this.slotnum;  // �� ��ü���� ����ϱ� ���ؼ� ������ ��ȣ�� �ο���
        AgainItemUi.Instance.AgainItemUiPenal.SetActive(true);  //�ٽ��ϱ� ��ư Ȱ��ȭ��Ű��
        
    }
    public void AgainItemYes()  //Ȯ�ι�ư�� ������ �������� �������� �����ϴ� �޼���
    {
        bool isUse = item.Use();
        if (isUse)
        {

            if (item.itemType == ItemType.AttakEquipment)
            {            
                Inven.Instance.playerWeapon.sprite = item.itemImage;
                Inven.Instance.AddEquipmentItem(slotnum);
                //���� ����ٰ� �÷��̾��� �̹����� �޾Ƽ� ��ü�� ���ش�

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
