using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour
{

    //击中的当前目标

    public GameObject Target;

    //倒计时

    private float countDownTime = 1f;

    //当前时间



    private float currentTime = 0;
    bool isDone = false;


    void Start()
    {

    }
    void Update()
    {

        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, forward, out hit, 500f, LayerMask.GetMask("Gaze")))
        {
            if (Target != hit.collider.gameObject)
            {
                isDone = false;
                Target = hit.transform.gameObject;
                GazeTip.Instance.Open(countDownTime,hit.point);
                currentTime = 0;
                if (Target.gameObject == hit.collider.gameObject)
                {
                }
                else
                {
                    //视线移出时，做一些初始化

                }
            }
                if (hit.transform.gameObject != Target)
                {
                if (Target != null)
                {
                }
                else
                {
                }
                }

                else //视线在此停留

                {

                    currentTime += Time.deltaTime;

                    //设定等待时间未结束

                    if (countDownTime - currentTime > 0)

                    {

                    }

                    else//达到设定条件(3秒后)

                    {
                    if (isDone) return;
                        GazeBase gazeFireItem = Target.GetComponent<GazeBase>();
                        if (gazeFireItem)
                        {
                            gazeFireItem.GazeToDo();
                        isDone = true;
                        }
                        currentTime = 0f;
                    }
                }
            }
            else
            //没有碰到物体
            {
            GazeTip.Instance.Close();
            Target = null;
            }
        }
    
}


