using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public GameObject PingTuGO;
    public Button StartBtn;
    public Text ContentText;
    public string StartStr;
    private void Awake()
    {
        StartBtn.onClick.AddListener(()=> {
            gameObject.SetActive(false);
            PingTuGO.SetActive(true);
        });
    }
    private void OnEnable()
    {
        ContentText.DOText(StartStr, StartStr.Length/6f);
    }
}
