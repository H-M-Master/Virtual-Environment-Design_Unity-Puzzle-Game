using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("高斯模糊")]
    public GameObject BackBlur;

    [Header("物品信息")]
    public GameObject itemPickMessage;
    public Image itemIcon;
    public Text itemName;

    [Header("UI检查")]
    public GameObject[] UIPanels;

    public GameObject warningPanel;

    public bool CanMove = true;

    public ItemShowManager showManager;
    public KeyPadSystem keyPadManager;

    public InventoryObject inventory;


    public bool picture;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        CanMove = Check();

        if (picture )
        {
            Picutre();
        }
    }


    #region 物品拾取面板
    public void ShowItemMessage(Sprite icon,string name)
    {
        itemIcon.sprite = icon;
        itemName.text = name;
        itemPickMessage.SetActive(true);
    }

    public void HideItemMessage()
    {
        itemPickMessage.SetActive(false);
    }
    #endregion


    #region UI面板检查
  
    public bool Check()
    {
        for (int i = 0; i < UIPanels.Length; i++)
        {
            if (UIPanels[i].activeInHierarchy)
                return false;
        }
        return true;
    }
    #endregion


    #region 高斯模糊控制
    public void ShowBlur()
    {
        BackBlur.SetActive(true);
    }

    public void HideBlur()
    {
        BackBlur.SetActive(false);
    }
    #endregion


    public void ItemShow(GameObject obj)
    {
        UIPanels[2].SetActive(true);
        showManager.startPos = obj.transform.localPosition;
        showManager.startRot = obj.transform.localEulerAngles;
        obj.transform.SetParent(showManager.showTrans);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = Vector3.zero;
        showManager.curObj = obj;
        
        showManager.active = true;
    }

    public void ItemShowClose()
    {
        UIPanels[2].SetActive(false);
        if (showManager.inventory == false)
        {
            showManager.curObj.GetComponent<InteractionItem>().wasShow = false;
            showManager.curObj.transform.SetParent(null);
            showManager.curObj.transform.localPosition = showManager.startPos;
            showManager.curObj.transform.localEulerAngles = showManager.startRot;
            showManager.active = false;
        }
        else
        {
            
            InventoryShowClose();
            showManager.inventory = false;
        }
       
    }

    public void InventoryShow(GameObject obj)
    {
        UIPanels[2].SetActive(true);
        HideBlur();
        UIPanels[0].SetActive(false);
        GameObject temp = Instantiate(obj, showManager.showTrans);
        temp.transform.localPosition = Vector3.zero;
        showManager.inventory = true;
        showManager.active = true;
    }

    public void InventoryShowClose()
    {
        ShowBlur();
        UIPanels[0].SetActive(true);
        Destroy(showManager.showTrans.GetChild(0).gameObject);
        showManager.active = false;
    }


    public void KeyPadShow()
    {
        ShowBlur();
        UIPanels[3].SetActive(true);
    }

    public void KeyPadClose()
    {
        HideBlur();
        UIPanels[3].SetActive(false);
    }



    public void DoWarning(string text)
    {
        StartCoroutine(ShowWarning(text));
    }
   public IEnumerator ShowWarning(string text)
    {
        warningPanel.GetComponentInChildren<Text>().text = text;
        warningPanel.SetActive(true);
      yield  return new WaitForSeconds(2f);
        warningPanel.SetActive(false);
    }


    public void Picutre()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (UIPanels[6].activeInHierarchy == false)
                UIPanels[6].SetActive(true);
            else
                UIPanels[6].SetActive(false);
        }
    }

}
