using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObj : MonoBehaviour
{
    public int id;
    public Animation anim;

    public bool canOpen;

    GameObject arrow;
    GameObject icon;

    private Transform player;
    InventoryObject inventory;

    public float distance;

    bool doorOpen = false;

    public string tips= "Warehouse door key required!";
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InputSystem>().inventory;

        arrow = transform.GetChild(0).GetChild(1).gameObject;
        icon = transform.GetChild(0).GetChild(0).gameObject;

    }

    private void Update()
    {

        CheckKey();

        distance = Vector3.Distance(transform.position, player.position);


        if (distance <= 5f && doorOpen==false)
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
        if (distance <= 4f && doorOpen == false)
        {
            icon.SetActive(true);
            icon.transform.LookAt(Camera.main.transform);
        }
        else
        {
            icon.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.F) && icon.activeInHierarchy && doorOpen == false)
        {
           
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (canOpen)
                    {
                        anim.Play();
                        doorOpen = true;
                    }
                else
                {
                    UIManager.instance.DoWarning(tips);
                }
                }
            

        }
    }

    private void OnMouseExit()
    {
        icon.SetActive(false);
    }
 
    public void CheckKey()
    {
        canOpen= inventory.FindItemById(id);
    }
}
