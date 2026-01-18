/***********************************************
******CS
***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class GazeBase : MonoBehaviour
{
    private EventTrigger trigger;
    
    private bool isOpen;
    /// <summary>
    /// 凝视时间
    /// </summary>
    private float maxTime=2f;
    /// <summary>
    /// 计时器
    /// </summary>
    private float timer=0;
    void Start()
    {

        //if (!GetComponent<EventTrigger>())
        //{
        //    trigger = gameObject.AddComponent<EventTrigger>();
        //}
        //else
        //{
        //    trigger = gameObject.GetComponent<EventTrigger>();
        //}
        //UnityAction<BaseEventData> click = new UnityAction<BaseEventData>(MyClick);
        //EventTrigger.Entry myclick = new EventTrigger.Entry();
        //myclick.eventID = EventTriggerType.PointerEnter;
        //myclick.callback.AddListener(click);

        //trigger.triggers.Add(myclick);

        //UnityAction<BaseEventData> _click = new UnityAction<BaseEventData>(MyClick_);
        //EventTrigger.Entry myclick_ = new EventTrigger.Entry();
        //myclick_.eventID = EventTriggerType.PointerExit;
        //myclick_.callback.AddListener(_click);
        //trigger.triggers.Add(myclick_);


    }

    //进入
    public virtual void MyClick(BaseEventData data)
    {
        Debug.Log("进入");
        GazeTip.Instance.Open(maxTime,Vector3.zero);
        isOpen = true;
        timer = 0;
    }
    //离开
    public virtual void MyClick_(BaseEventData data)
    {
        Debug.Log("离开");
        GazeTip.Instance.Close();
        isOpen = false;
        timer = 0;
    }
    public virtual void GazeToDo()
    {
        Debug.Log("凝视成功，调用事件");

    }
    private void Update()
    {
        //if (isOpen)
        //{
        //    if (timer >= maxTime)
        //    {
        //        GazeToDo();
        //        isOpen = false;
        //    }
        //    else
        //    {
        //        timer += Time.deltaTime;
        //    }
        //}
    }
}
