using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour, IPointerUpHandler //���� ��� ���� ������  //�����͸� �� �� ȣ�� �� �� �ֵ��� �ϴ� �̺�Ʈ�� ���� ���ؼ� ��ӹ���
{
    public int slotnum;
    public Item item;  // ������ Ŭ���� �����
    public Image itemIcon;  // �̹��� ���� -> ���Կ� �ִ� �̹��� ���� ����
    

    public GameObject AgainItemUi;
    public GameObject AgainItemYesBtn;
    public GameObject AgainItemNoBtn;

    public void Awake()
    {
       // ��ü�� �ʱ�ȭ ���������. playerWeapon =  GetComponent<SpriteRenderer>(); -> �� �÷��̾��� ���⸦ ����� ������ �� �־���Ѵ�.
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
        Debug.Log("�̰� ������?");
        AgainItemUi.SetActive(true);
        AgainItemUi.transform.position = this.transform.TransformPoint(new Vector3(166,-140, 0));
        // AgainItemYes();
    }
   public void AgainItemYes()
    {
        bool isUse = item.Use();
        if (isUse)
        {
            
            if(item.itemType == 0)
            {
                AgainItemUi.transform.position = new Vector3(-4,1,0);
                AgainItemUi.transform.position = transform.TransformPoint(new Vector3(0,0,0));
                Debug.Log("���� ����");
                Inven.Instance.playerWeapon.sprite = item.itemImage;
                //���� ����ٰ� �÷��̾��� �̹����� �޾Ƽ� ��ü�� ���ش�
            }
            Inven.Instance.RemoveItem(slotnum);  // 
        }
    }

    public void AgainItemNo()
    {
        AgainItemUi.SetActive(false);
    }
}
