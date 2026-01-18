using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemDatabase", menuName = "Player/Inventory System/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public ItemObjcet[] itemObjcets;


    [ContextMenu("Update ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < itemObjcets.Length; i++)
        {
            if (itemObjcets[i].id != i)
                itemObjcets[i].id = i;

        }
    }

    public ItemObjcet GetItemObject(int _id)
    {
        for(int i = 0; i < itemObjcets.Length; i++)
        {
            if(itemObjcets[i].id == _id)
            {
                return itemObjcets[i];
            }
        }
        return null;

    }



}
