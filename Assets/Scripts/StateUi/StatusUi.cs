using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUi : MonoBehaviour
{
    public GameObject statusUi;  // 인벤ui담을 오브젝트 만들기
    bool activeStatus = false;  //처음에는 fasle로 설정하기
    // Start is called before the first frame update
    void Start()
    {
        statusUi.SetActive(activeStatus);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))  //ㅣ키를 통해서 인벤토리를 관리
        {
            activeStatus = !activeStatus;
            statusUi.SetActive(activeStatus);
        }
    }
}
