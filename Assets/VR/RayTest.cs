/***********************************************
******CS
***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) 
            {
                Debug.LogWarning("当前点击物品："+hit.collider.name);
            }
        }
    }
}
