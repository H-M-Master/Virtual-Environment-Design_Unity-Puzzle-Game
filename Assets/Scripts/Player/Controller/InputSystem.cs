using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public InventoryObject inventory;

    [Header("UI面板")]
    public GameObject inventoryPanel;
    public GameObject showPanel;
    public GameObject usePanel;

    public Animator armAnim;

    public PlayerStatus playerStatus;

    [Header("输入数据")]
    public float horziontal;
    public float vertical;
    public float mouseX;
    public float mouseY;


    private void Update()
    {
        UIPanelControl();
        PlayerInnputManager();

    }



    public void UIPanelControl()
    {
        if (Input.GetKeyDown(KeyCode.Tab) )
        {
            if (inventoryPanel.activeInHierarchy)
            {
                UIManager.instance.HideBlur();
                inventoryPanel.SetActive(false);
            }
            else if(UIManager.instance.CanMove)
            {
                UIManager.instance.ShowBlur();
                inventoryPanel.SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.instance.UIPanels[4].activeInHierarchy == false)
                GameManager.instance.Esc();
            else
                GameManager.instance.ContinueGame();
        }
    }



    public void PlayerInnputManager()
    {
        if (UIManager.instance.CanMove)
        {
            horziontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        else
        {
            horziontal = 0f;
            vertical = 0f;
        }

        if (horziontal != 0 || vertical != 0)
        {
            if (playerStatus.isCrouch == false)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerStatus.isRun = true;
                    playerStatus.isWalk = false;
                }
                else
                {
                    playerStatus.isRun = false;
                    playerStatus.isWalk = true;
                }
            }
            else
            {
                playerStatus.isRun = false;
                playerStatus.isWalk = true;
            }
        }
        else
        {
            playerStatus.isWalk = false;
            playerStatus.isRun = false;
        }

        if (Input.GetKeyDown(KeyCode.C) && UIManager.instance.CanMove)
        {
            playerStatus.isCrouch = !playerStatus.isCrouch;
        }

    }

  
  

    private void OnApplicationQuit()
    {
        inventory.Container = new InvetorySlot[12];
    }
}
