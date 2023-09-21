using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AgainItemUi : MonoBehaviour
{
    public static AgainItemUi Instance;   // ΩÃ±€≈Ê»≠ Ω√≈¥
    private void Awake()
    {
        isAgainItem = false;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public  bool isAgainItem = false;
    public  bool yesAgainItem = false;
    public GameObject AgainItemUiPenal;
    public GameObject AgainItemYesBtn;
    public GameObject AgainItemNoBtn;

    //public delegate void YesAgainItem();  //µ®∏Æ∞‘¿Ã∆Æ «¸Ωƒ ∏∏µÈ±‚
    //public YesAgainItem yesAgainItem;  // µ®∏Æ∞‘¿Ã∆Æ  ∏∏µÎ


    private void Update()
    {
        if (isAgainItem) { AgainItemUiPenal.SetActive(true); }
        else { AgainItemUiPenal.SetActive(false); }
    }

    public void AgainItemYesYes()
    {

       // yesAgainItem.Invoke();
        yesAgainItem = true;
        AgainItemUiPenal.SetActive(false);
    }

    public void AgainItemNo()
    {
        AgainItemUiPenal.SetActive(false);
    }

}
