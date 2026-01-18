using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractionBase
{
    protected override void DoSomething()
    {
        base.DoSomething();
        PublicAttribute.Instance.isHaveAKey = true;
        Interaction = false;
        Close();
    }
}
