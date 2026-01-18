using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform playerBody = null;
    [SerializeField] float mouseSensitivity = 5f;


    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;


    public bool lockCursor = true;

    public float minAngle;
    public float maxAngle;

    float cameraPitch = 0.0f;





    Vector2 curMouseDelta = Vector2.zero;
    Vector2 curMouseDeltaVelocity = Vector2.zero;
    //public UICheck check;
    public InputSystem input;

    private void Update()
    {
        if (UIManager.instance.CanMove || UIManager.instance.UIPanels[2].activeInHierarchy)
        {
            MouseLookUpdate();
            lockCursor = true;
        }
        else
        {
            lockCursor = false;
        }



        CursorController();
    }

    void MouseLookUpdate()
    {
        Vector2 targetMouseDelta = new Vector2(input.mouseX, input.mouseY);

        curMouseDelta = Vector2.SmoothDamp(curMouseDelta, targetMouseDelta, ref curMouseDeltaVelocity, mouseSmoothTime,3f,1);

        cameraPitch -= curMouseDelta.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, minAngle, maxAngle);

        transform.localEulerAngles = Vector3.right * cameraPitch;

        playerBody.Rotate(Vector3.up * curMouseDelta.x * mouseSensitivity);
    }

    void CursorController()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

   
}
