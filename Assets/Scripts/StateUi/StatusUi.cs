using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUi : MonoBehaviour
{
    public GameObject statusUi;  // �κ�ui���� ������Ʈ �����
    bool activeStatus = false;  //ó������ fasle�� �����ϱ�
    // Start is called before the first frame update
    void Start()
    {
        statusUi.SetActive(activeStatus);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))  //��Ű�� ���ؼ� �κ��丮�� ����
        {
            activeStatus = !activeStatus;
            statusUi.SetActive(activeStatus);
        }
    }
}
