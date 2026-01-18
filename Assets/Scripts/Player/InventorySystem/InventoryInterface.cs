using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject slotPrefab;

    public Sprite haveItemBack;
    public Sprite emptyItemBack;

    public Text itemName;
    public Text itemIntroduction;

    public Dictionary<InvetorySlot, GameObject> SlotsOnInterface = new Dictionary<InvetorySlot, GameObject>();
    private void Start()
    {
        BuildSlot();
        itemName.text = "";
        itemIntroduction.text = "";

    }

    public void BuildSlot()
    {
        for(int i = 0; i < inventory.Container.Length; i++)
        {
            GameObject slot = Instantiate(slotPrefab, transform);

            AddEvent(slot, EventTriggerType.PointerEnter, delegate { OnEnter(slot); });
            AddEvent(slot, EventTriggerType.PointerExit, delegate { OnExit(slot); });
            AddEvent(slot, EventTriggerType.BeginDrag, delegate { OnDragStart(slot); });
            AddEvent(slot, EventTriggerType.EndDrag, delegate { OnDragEnd(slot); });
            AddEvent(slot, EventTriggerType.Drag, delegate { OnDrag(slot); });
            AddEvent(slot, EventTriggerType.PointerClick, delegate { OnPointerClick(slot); });

            SlotsOnInterface.Add(inventory.Container[i],slot);
        }
    }

    private void Update()
    {
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        for(int i = 0; i <inventory.Container.Length;i++)
        {
            if (inventory.Container[i].id < 0)
            {
                SlotsOnInterface[inventory.Container[i]].GetComponent<Image>().sprite = emptyItemBack;
                SlotsOnInterface[inventory.Container[i]].transform.GetChild(0).GetComponent<Image>().enabled = false;
                SlotsOnInterface[inventory.Container[i]].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                SlotsOnInterface[inventory.Container[i]].GetComponent<Image>().sprite = haveItemBack;
                SlotsOnInterface[inventory.Container[i]].transform.GetChild(0).GetComponent<Image>().enabled = true;
                SlotsOnInterface[inventory.Container[i]].transform.GetChild(0).GetComponent<Image>().sprite = inventory.itemDatabase.GetItemObject(inventory.Container[i].id).uiSprite;
                SlotsOnInterface[inventory.Container[i]].transform.GetChild(1).gameObject.SetActive(true);
                SlotsOnInterface[inventory.Container[i]].transform.GetChild(1).GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString();
            }
        }
    }


    public void OnEnter(GameObject obj)
    {
        if (GetSlot(obj) != null && GetSlot(obj).id>=0)
        {
            itemName.text = inventory.itemDatabase.GetItemObject(GetSlot(obj).id).itemName;
            itemIntroduction.text = inventory.itemDatabase.GetItemObject(GetSlot(obj).id).introduction;
        }
    }

    public void OnExit(GameObject obj)
    {
        itemName.text = "";
        itemIntroduction.text = "";
    }

    public void OnDragStart(GameObject obj)
    {

    }

    public void OnDrag(GameObject obj)
    {

    }

    public void OnDragEnd(GameObject obj)
    {

    }

    public void OnPointerClick(GameObject obj)
    {
        if (GetSlot(obj) != null && GetSlot(obj).id >= 0)
        {
            if (inventory.itemDatabase.GetItemObject(GetSlot(obj).id).prefab != null)
            {
                UIManager.instance.InventoryShow(inventory.itemDatabase.GetItemObject(GetSlot(obj).id).prefab);
            }
        }
    }
    public InvetorySlot GetSlot(GameObject obj)
    {
        foreach(var temp in SlotsOnInterface)
        {
            if (temp.Value == obj)
                return temp.Key;
        }
        return null;
    }


    public void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTirgger = new EventTrigger.Entry();
        eventTirgger.eventID = type;
        eventTirgger.callback.AddListener(action);
        trigger.triggers.Add(eventTirgger);

    }

}
