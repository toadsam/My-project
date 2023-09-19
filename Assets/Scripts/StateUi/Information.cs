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
    CharacterStatsHandler characterStatsHandler = new CharacterStatsHandler();
    //public CharacterStats CurrentStates;
    // Start is called before the first frame update
    void Start()
    {
      //  Power.text = characterStatsHandler.CurrentStates.attackSO.power.ToString();
        //speed.text = characterStatsHandler.CurrentStates.speed.ToString();
        //maxHealth.text = characterStatsHandler.CurrentStates.maxHealth.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //Power.text = attackSO.power.ToString();
    }

}
