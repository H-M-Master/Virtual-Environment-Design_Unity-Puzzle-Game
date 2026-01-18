using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaperItem : MonoBehaviour
{
    public ItemObjcet itemObjcet;
    InventoryObject inventory;


    GameObject arrow;
    GameObject icon;

    private Transform player;
    public float distance;


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

    private void OnMouseOver()
    {
        if (distance <= 2f)
        {
            icon.SetActive(true);
            icon.transform.LookAt(Camera.main.transform);
        }
        else
        {
            icon.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.F) && icon.activeInHierarchy )
        {      
            AudioManager.instance.PlayOnceClip(AudioManager.instance.effectAudio, AudioManager.instance.effClips[0]);
            inventory.AddItemByItemObject(itemObjcet, this.gameObject);
            

        }
    }

    private void OnMouseExit()
    {
        icon.SetActive(false);
    }
}


