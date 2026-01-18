using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InteractionType
{
    Pick,
    Show
}

public class InteractionItem : MonoBehaviour
{
    public InteractionType interactionType;
    public ItemObjcet itemObjcet;
    InventoryObject inventory;


    GameObject arrow;
    GameObject icon;

    private Transform player;
    public float distance;

    public bool wasShow;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InputSystem>().inventory;

      
        arrow = transform.GetChild(0).GetChild(1).gameObject;
        icon = transform.GetChild(0).GetChild(0).gameObject;

    }

    private void Update()
    {

        distance = Vector3.Distance(transform.position, player.position);
        if (wasShow==false)
        {
            if (distance <= 2.5f)
            {
                arrow.SetActive(true);
                arrow.transform.LookAt(Camera.main.transform);

            }
            else
            {
                arrow.SetActive(false);
                icon.SetActive(false);
            }
        }
        else
        {
            arrow.SetActive(false);
            icon.SetActive(false);
            UIManager.instance.HideItemMessage();
        }
    }

    private void OnMouseOver()
    {
        if (distance <= 1.8f)
        {
            icon.SetActive(true);
            UIManager.instance.ShowItemMessage(itemObjcet.uiSprite, itemObjcet.itemName);
            icon.transform.LookAt(Camera.main.transform);
        }
        else
        {
            icon.SetActive(false);
            UIManager.instance.HideItemMessage();
        }


        if (Input.GetKeyDown(KeyCode.F) && icon.activeInHierarchy && UIManager.instance.CanMove)
        {
            if (interactionType == InteractionType.Pick)
            {
                inventory.AddItemByItemObject(itemObjcet, this.gameObject);
                AudioManager.instance.PlayOnceClip(AudioManager.instance.effectAudio, AudioManager.instance.effClips[0]);
                UIManager.instance.HideItemMessage();
            }
            else
            {
                wasShow = true;
                AudioManager.instance.PlayOnceClip(AudioManager.instance.effectAudio, AudioManager.instance.effClips[0]);
                UIManager.instance.HideItemMessage();
                UIManager.instance.ItemShow(gameObject);
            }
        }
    }

    private void OnMouseExit()
    {
        icon.SetActive(false);
        UIManager.instance.HideItemMessage();
    }
}


