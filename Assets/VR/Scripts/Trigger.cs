/***********************************************
******CS
***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public InteractionBase IB;
    private void Awake()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IB.Open();
            Debug.Log("进入触发区域");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IB.Close();
            Debug.Log("离开触发区域");
        }
    }
}
