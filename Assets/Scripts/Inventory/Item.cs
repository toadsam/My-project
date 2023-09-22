using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    AttakEquipment,
    HatEquipment,
    Consumables,
    Etc
}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemNmae;
    public Sprite itemImage;
    public int addAttack;
    public int addDefence;
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach(ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }
        return isUsed;
    }
}
