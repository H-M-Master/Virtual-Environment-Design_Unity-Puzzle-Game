using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : InteractionBase
{
    public InteractionBase IB;
    
    protected override void DoSomething()
    {
        base.DoSomething();
        if (PublicAttribute.Instance.isHaveAKey)
        {
            //播放动画
            GetComponent<Animation>().Play();
            Interaction = false;
            Close() ;
            IB.Open();
        }
        else 
        {
            //寻找Key
            EventManager.Instance.TipChange?.Invoke("Find Key");
        }
    }
}
