using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBtn : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Status;
    public GameObject Information;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GotoStatus()
    {
        Inventory.SetActive(false);
        Status.SetActive(false);
        Information.SetActive(true);
    }
}
