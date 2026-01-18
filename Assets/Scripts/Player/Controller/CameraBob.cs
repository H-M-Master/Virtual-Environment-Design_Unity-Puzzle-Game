using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public Transform headTrans;
    public Transform cameraTrans;

     float bobFrequency = 5f;
     float bobHorizontal = 0.1f;
     float bobVertocal = 0.1f;

    [Range(0, 1)] public float headBobSmoothing = 0.1f;


    public InputSystem input;
    public bool isWalking;
    private float moveTime;
    private Vector3 targetCameraPosition;

    private void Update()
    {
        if (UIManager.instance.CanMove)
            HeadBob();
    }

    public Vector3 CalculateHeadBobOffset(float t)
    {
        float horizontalOffset = 0;
        float verticalOffset = 0;
        Vector3 offset = Vector3.zero;

        if (t > 0)
        {
            horizontalOffset = Mathf.Cos(t * bobFrequency) * bobHorizontal;
            verticalOffset = Mathf.Sin(t * bobFrequency * 2) * bobVertocal;
            offset = headTrans.right * horizontalOffset + headTrans.up * verticalOffset;
        }
        return offset;
    }

    public void HeadBob()
    {
        if (input.horziontal == 0 && input.vertical == 0)
        {
            isWalking = false;
        }
        else
        {
            if (input.playerStatus.isRun)
            {
                bobFrequency = 7;
                bobHorizontal = .1f;
                bobVertocal = .1f;
            }
            else
            {
                bobFrequency = 5;
                bobHorizontal = .05f;
                bobVertocal = .05f;
            }

            isWalking = true;
        }


        if (!isWalking) moveTime = 0;
        else moveTime += Time.deltaTime;

        targetCameraPosition = headTrans.position + CalculateHeadBobOffset(moveTime);

        cameraTrans.position = Vector3.Lerp(cameraTrans.position, targetCameraPosition, headBobSmoothing);
        if ((cameraTrans.position - targetCameraPosition).magnitude <= 0.001)
            cameraTrans.position = targetCameraPosition;
    }

}
