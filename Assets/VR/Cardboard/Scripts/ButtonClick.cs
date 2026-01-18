using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : GazeBase
{
    private Button Btn;
    private void Awake()
    {
        Btn = GetComponent<Button>();
    }
    public override void GazeToDo()
    {
        base.GazeToDo();
        if (!Btn) return;
        else
        {
            Btn.onClick?.Invoke();
            Debug.Log("点击按钮成功");
        }
        
    }
}
