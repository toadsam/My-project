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
    AgainItemUi againItemUi;



    public void Awake()
    {
       
        //�������� ����Ѵٴ� ��������Ʈ �ޱ�
                                                  // ��ü�� �ʱ�ȭ ���������. playerWeapon =  GetComponent<SpriteRenderer>(); -> �� �÷��̾��� ���⸦ ����� ������ �� �־���Ѵ�.
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
        againItemUi.isAgainItem = true;  //�г� Ȱ��ȭ ��Ŵ
        
        //bool isUse = item.Use();
        //if (isUse)
        //{

        //    if (item.itemType == 0)
        //    {

        //        Debug.Log("���� ����");
        //        Inven.Instance.playerWeapon.sprite = item.itemImage;
        //        //���� ����ٰ� �÷��̾��� �̹����� �޾Ƽ� ��ü�� ���ش�
        //    }
        //    Inven.Instance.RemoveItem(slotnum);  // 
        //}
        //Debug.Log("�̰� ������?");
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

                Debug.Log("���� ����");
                Inven.Instance.playerWeapon.sprite = item.itemImage;
                //���� ����ٰ� �÷��̾��� �̹����� �޾Ƽ� ��ü�� ���ش�
            }
            Inven.Instance.RemoveItem(slotnum);  // 
        }
    }

    
}
