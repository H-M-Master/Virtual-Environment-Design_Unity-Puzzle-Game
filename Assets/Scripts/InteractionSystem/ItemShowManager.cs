using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShowManager : MonoBehaviour
{
    public Transform showTrans;
    public GameObject curObj;
    public Vector3 startPos;
    public Vector3 startRot;

    public bool active = false;

    public float speed = 2;

    public bool inventory;

    private void Update()
    {
        if (active)
        {
            RotateControl();
            if (Input.GetMouseButtonDown(1))
            {
                UIManager.instance.ItemShowClose();
            }
        }
    }
    public void RotateControl()
    {
        showTrans. Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * speed, -Input.GetAxis("Mouse X") * Time.deltaTime * speed, 0);

    }

   

}
