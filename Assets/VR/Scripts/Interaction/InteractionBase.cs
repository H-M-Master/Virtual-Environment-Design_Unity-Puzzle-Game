using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : ObjectDoubleClick
{
    private Collider thisCollider;
    public GameObject TipGO;
    public bool Interaction=true;
    public GameObject[] ShowGOs;
    private void Awake()
    {
        thisCollider = GetComponent<BoxCollider>();
        thisCollider.enabled = false;
        TipGO.SetActive(false);
        foreach (var go in ShowGOs) 
        {
            go.SetActive(false);
        }
    }
    public void Open() 
    {
        if (!Interaction) return;
        thisCollider.enabled = true;
        TipGO.SetActive(true);
    }
    public void Close() 
    {
        thisCollider.enabled = false;
        TipGO.SetActive(false);
    }
    protected override void DoSomething()
    {
        base.DoSomething();
        Debug.Log("被点击！");
        foreach (var go in ShowGOs)
        {
            go.SetActive(true);
        }
    }
}
