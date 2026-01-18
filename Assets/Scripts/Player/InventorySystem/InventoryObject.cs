using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName ="Player/Inventory System/InventoryObject")]
public class InventoryObject : ScriptableObject
{
    public ItemDatabase itemDatabase;
    public InvetorySlot[] Container = new InvetorySlot[12];


    public void AddItemByItemObject(ItemObjcet itemObjcet,GameObject obj)
    {
        if (itemObjcet.stackable)
        {
            if (FindSameIdSlot(itemObjcet.id) != null)
            {
                FindSameIdSlot(itemObjcet.id).amount++;
                Destroy(obj);
            }
            else
            {
                if (FindEmptySlot() != null)
                {
                    FindEmptySlot().AddItem(itemObjcet);
                    Destroy(obj);
                }
            }
        }
        else
        {
            if (FindEmptySlot() != null)
            {
                FindEmptySlot().AddItem(itemObjcet);
                Destroy(obj);
            }
        }
    }

    public void AddItemByItemObject(ItemObjcet itemObjcet)
    {
        if (itemObjcet.stackable)
        {
            if (FindSameIdSlot(itemObjcet.id) != null)
            {
                FindSameIdSlot(itemObjcet.id).amount++;
            }
            else
            {
                if (FindEmptySlot() != null)
                {
                    FindEmptySlot().AddItem(itemObjcet);
                }
            }
        }
        else
        {
            if (FindEmptySlot() != null)
            {
                FindEmptySlot().AddItem(itemObjcet);
            }
        }
    }
    public InvetorySlot FindEmptySlot()
    {
        for(int i = 0; i < Container.Length; i++)
        {
            if (Container[i].id < 0)
            {
                return Container[i];
            }
        }
        Debug.Log("格子已满！");
        return null;
    }

    public InvetorySlot FindSameIdSlot(int _id)
    {
        for (int i = 0; i < Container.Length; i++)
        {
            if (Container[i].id ==_id)
            {
                return Container[i];
            }
        }
        Debug.Log("未找到相同的物品格！");
        return null;
    }

    public bool FindItemById(int id)
    {
        for(int i = 0; i < Container.Length; i++)
        {
            if (Container[i].id == id)
                return true;
        }
        return false;
    }  

}


[System.Serializable]
public class InvetorySlot
{
    public int id=-1;
    public string itemName;
    public int amount=0;


    public void AddItem(ItemObjcet itemObjcet)
    {
        id = itemObjcet.id;
        itemName = itemObjcet.itemName;
        amount++;
    }
}
