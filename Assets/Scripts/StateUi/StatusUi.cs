using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUi : MonoBehaviour
{
    public GameObject statusUi;  // �κ�ui���� ������Ʈ �����
    bool activeStatus = false;  //ó������ fasle�� �����ϱ�
    public TMP_Text attackTxt;
    public TMP_Text defenceTxt;
    public TMP_Text heartTxt;
    public TMP_Text criticalTxt;
    public TMP_Text goldTXt;
    public TMP_Text levelTxt;
    public CharacterStatsHandler playerStatsHandler;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        statusUi.SetActive(activeStatus);
        playerStatsHandler = player.GetComponent<CharacterStatsHandler>();
    }

    private void OnEnable()
    {
       // attackTxt.text = playerStatsHandler.CurrentStates.attackSO.power.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))  //��Ű�� ���ؼ� �κ��丮�� ����
        {
            activeStatus = !activeStatus;
            statusUi.SetActive(activeStatus);
            attackTxt.text = playerStatsHandler.CurrentStates.attackSO.power.ToString();
            defenceTxt.text = playerStatsHandler.CurrentStates.attackSO.defence.ToString();
            heartTxt.text = playerStatsHandler.CurrentStates.maxHealth.ToString();
            goldTXt.text = playerStatsHandler.CurrentStates.money.ToString();
            levelTxt.text = playerStatsHandler.CurrentStates.level.ToString();
            criticalTxt.text = playerStatsHandler.CurrentStates.attackSO.criticalPower.ToString();

        }
    }

}

