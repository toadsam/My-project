using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class EquipPanel : MonoBehaviour
{
    public GameObject WeaponImage;
    public Sprite weaponImage;
    public GameObject HatImage;
    // Start is called before the first frame update
    void Start()
    {
        weaponImage = WeaponImage.GetComponent<Image>().sprite;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        Debug.Log(Inven.Instance.equipmentItems.Count);
        for(int i = 0; i < Inven.Instance.equipmentItems.Count; i++) //널값 계산하기 
        {

            switch(Inven.Instance.equipmentItems[i].itemType)
            {
                case ItemType.AttakEquipment:
                    WeaponImage.GetComponent<Image>().sprite = Inven.Instance.equipmentItems[i].itemImage;
                    break;
                case ItemType.HatEquipment:
                    HatImage.GetComponent<Image>().sprite = Inven.Instance.equipmentItems[i].itemImage;
                    break;
                default:
                    break;




            }
            //if (Inven.Instance.equipmentItems[i].itemType == 0)
            //{
            //    Debug.Log(i);
            //    WeaponImage.GetComponent<Image>().sprite = Inven.Instance.equipmentItems[i].itemImage;
            //}
            
            //{
            //    Debug.Log(i);
            //    WeaponImage.GetComponent<Image>().sprite = Inven.Instance.equipmentItems[i].itemImage;
            //}

        }
        
    }
}
