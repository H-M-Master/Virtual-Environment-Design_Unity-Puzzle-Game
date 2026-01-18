using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : MonoBehaviour
{
    public Text TipText;
    private void Awake()
    {
        TipText.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        EventManager.Instance.TipChange += OnTipChange;
    }

    private void OnDisable()
    {
        EventManager.Instance.TipChange -= OnTipChange;
    }

    private void OnTipChange(string tipStr)
    {
        TipText.gameObject.SetActive(true);
        TipText.text = tipStr;
        StopAllCoroutines();
        StartCoroutine(HidTip());
    }
    IEnumerator HidTip() 
    {
        yield return new WaitForSeconds(2f);
        TipText.gameObject.SetActive(false);
    }
}
