using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Equipment/Attack")]
public class ItemAttackEtf : ItemEffect
{
    // Start is called before the first frame update
    public override bool ExecuteRole()
    {
        Debug.Log("���ݷ� ����");
        return true;

    }
}
