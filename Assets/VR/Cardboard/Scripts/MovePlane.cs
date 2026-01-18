using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MovePlane : GazeBase
{
    public Transform VRCameraTran;
    public bool isMove = true;
    public override void GazeToDo()
    {
        base.GazeToDo();
        if (!isMove) return;
        Move();
        Debug.Log("移动");

    }
    private void Move()
    {
        Vector3 forward =Camera.main.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, forward, out hit, 10f, LayerMask.GetMask("Gaze")))
        {
            if (hit.collider.name == this.name)
            {
                // VRCameraTran.position = hit.point + new Vector3(0f, 1.8f, 0f);
                if (SceneManager.GetActiveScene().buildIndex==0)
                {
                    VRCameraTran.DOMove(hit.point + new Vector3(0f, 1.8f, 0f), 0.3f);
                }

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    VRCameraTran.DOMove(hit.point + new Vector3(0f, 0.7f, 0f), 0.3f);
                }

            }
        }
    }
}
