using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this; 
    }
    public List<Item> itemDB = new List<Item>();  //������ ���̽��� ��� ����Ʈ

    public GameObject fieldItemPrefab;  // �����鸸���
    public Vector3[] pos;  // ��ġ����

    private void Start()
    {
        for(int i = 0; i < 8; i++) //�ʵ忡 �Ѹ��� �޼���
        {
           GameObject go = Instantiate(fieldItemPrefab, pos[i],Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, itemDB.Count)]);
        }
    }

}
