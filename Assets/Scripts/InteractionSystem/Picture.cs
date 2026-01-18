using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour {

    Transform player;
    float distance;

    public GameObject pictureTips;

    public float minDis = 2f;

    bool isShow;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (UIManager.instance.UIPanels[6].activeInHierarchy)
        {
            isShow = true;
        }
        else
        {
            isShow = false;
        }

        if (isShow)
        {
            pictureTips.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (distance <= minDis)
        {
            pictureTips.SetActive(true);
            UIManager.instance.picture = true;
        }
        else
        {
            UIManager.instance.picture = false;
            pictureTips.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        pictureTips.SetActive(false);
    }
}
