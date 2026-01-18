using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemObject", menuName = "Player/Inventory System/ItemObject")]
public class ItemObjcet : ScriptableObject
{  
    public int id;
    public bool stackable;
    public Sprite uiSprite;
    public GameObject prefab;
    public string itemName;
    [TextArea(15,25)]
    public string introduction;
    
}
