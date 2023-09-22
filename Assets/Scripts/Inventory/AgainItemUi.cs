using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AgainItemUi;
using static UnityEditor.Progress;

public class AgainItemUi : MonoBehaviour
{
    public static AgainItemUi Instance;   // ΩÃ±€≈Ê»≠ Ω√≈¥
    private void Awake()
    {
        //isAgainItem = false;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // public  bool isAgainItem;
    

    public GameObject AgainItemUiPenal;
    public GameObject AgainItemYesBtn;
    public GameObject AgainItemNoBtn;

    public bool isYesBtn = false;
    public delegate void YesAgainItem();  //µ®∏Æ∞‘¿Ã∆Æ «¸Ωƒ ∏∏µÈ±‚
    public YesAgainItem yesAgainItem;  // µ®∏Æ∞‘¿Ã∆Æ  ∏∏µÎ



    public void AgainItemYesYes()
    {
       
        AgainItemUiPenal.SetActive(false);
        isYesBtn = true; 

    }

    public void AgainItemNo()
    {
        AgainItemUiPenal.SetActive(false);
    }

}
