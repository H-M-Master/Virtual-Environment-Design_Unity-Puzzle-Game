using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadSystem : MonoBehaviour
{
    public int[] keyCode = new int[4];
    public Text[] showCode = new Text[4];
    public Button[] inputBtn = new Button[10];

    public int index = 0;

    public Animation anim;

    private void OnEnable()
    {
        Clear();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            UIManager.instance.KeyPadClose();
        }
    }
    public void Clear()
    {
        index = 0;
        for(int i = 0; i < showCode.Length; i++)
        {
            showCode[i].text = "-";
        }
    }

    public void Check()
    {
        for (int i = 0; i < showCode.Length; i++)
        {
            if (showCode[i].text != keyCode[i].ToString())
            {
                //Debug.Log("密码错误");
                UIManager.instance.DoWarning("Wrong password!");
                return;
            }
        }

        //Debug.Log("密码正确");
        anim.Play();
        UIManager.instance.KeyPadClose();
        GameManager.instance.GameWin();
        

    }

    public void InputNum(int num)
    {
        if (index < 3)
        {
            showCode[index].text = num.ToString();
            index++;
        }
        else
        {
            Debug.Log("最多输入3位");
        }
    }



    public void ObjRotate()
    {

    }
}
