using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Information : MonoBehaviour
{
    public TMP_Text Power;
    public TMP_Text speed;
    public TMP_Text maxHealth;
    //public AttackSO attackSO;
    // CharacterStatsHandler statsHandler;
    //public CharacterStats CurrentStates;
    protected CharacterStatsHandler Stats { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        Stats = GetComponent<CharacterStatsHandler>();  //��...��� �����ϴ� ���� ������ �˾ƺ���
        
       // Debug.Log(Stats.CurrentStates.attackSO.delay);
       // Debug.Log("��");
        // statsHandler = GetComponent<CharacterStatsHandler>();
        //// Power.text = statsHandler.
        // speed.text = statsHandler.CurrentStates.speed.ToString();
        // maxHealth.text = statsHandler.CurrentStates.maxHealth.ToString();

    }
     void OnEnable()  //Ȱ��ȭ �ɶ����� �޼��� ����
    {
       // Debug.Log(1);
        //Power.text = Stats.CurrentStates.attackSO.power.ToString();
        //speed.text = Stats.CurrentStates.speed.ToString();
        //maxHealth.text = Stats.CurrentStates.maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Power.text = attackSO.power.ToString();
    }

}
