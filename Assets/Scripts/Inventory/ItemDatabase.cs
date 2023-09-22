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
    public List<Item> itemDB = new List<Item>();  //데이터 베이스를 담는 리스트

    public GameObject fieldItemPrefab;  // 프리펩만들기
    public Vector3[] pos;  // 위치선정

    private void Start()
    {
        for(int i = 0; i < 8; i++) //필드에 뿌리는 메서드
        {
           GameObject go = Instantiate(fieldItemPrefab, pos[i],Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, itemDB.Count)]);
        }
    }

}
