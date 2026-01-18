using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadObj : MonoBehaviour
{
    GameObject arrow;
    GameObject icon;

    private Transform player;
    public float distance;

    public int[] code = new int[4];

    public Animation anim;

    
    public bool wasOpen;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


        arrow = transform.GetChild(0).GetChild(1).gameObject;
        icon = transform.GetChild(0).GetChild(0).gameObject;

    }

    private void Update()
    {
        if (wasOpen == false)
        {
            distance = Vector3.Distance(transform.position, player.position);
            if (UIManager.instance.CanMove)
            {
                if (distance <= 2.5f)
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
            else
            {
                arrow.SetActive(false);
                icon.SetActive(false);
            }
        }
        else
        {
            arrow.SetActive(false);
            icon.SetActive(false);

        }
    }

    private void OnMouseOver()
    {
        if (wasOpen == false)
        {
            if (distance <= 2f)
            {
                icon.SetActive(true);
                icon.transform.LookAt(Camera.main.transform);
            }
            else
            {
                icon.SetActive(false);
            }


            if (Input.GetKeyDown(KeyCode.F) && UIManager.instance.CanMove)
            {
                AudioManager.instance.PlayOnceClip(AudioManager.instance.effectAudio, AudioManager.instance.effClips[0]);

                for (int i = 0; i < code.Length; i++)
                {
                    UIManager.instance.keyPadManager.keyCode[i] = code[i];
                }
                UIManager.instance.keyPadManager.anim = anim;
                UIManager.instance.KeyPadShow();
            }
        }
    }

    private void OnMouseExit()
    {
        if(wasOpen==false)
        icon.SetActive(false);
    }
}
