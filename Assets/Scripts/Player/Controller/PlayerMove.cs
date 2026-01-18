using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float gravity = -13f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float curSpeed;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float crouchSpeed = 2f;

    float velocityY = 0f;
    CharacterController characterController = null;

    Vector2 curDir = Vector2.zero;
    Vector2 curDirVelocity = Vector2.zero;

    public PlayerStatus playerStatus;
    public InputSystem input;
    public FootStepSystem stepSystem;

    public Transform headTrans;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdateMovement();

        if (playerStatus.isWalk || playerStatus.isRun)
        {
            if (stepSystem.canPlay)
            {
                if (playerStatus.isWalk)
                {
                    stepSystem.footStepTimer = stepSystem.walkTimer;
                    stepSystem.curClips = stepSystem.rockClipsN;
                }
                if (playerStatus.isRun)
                {
                    stepSystem.footStepTimer = stepSystem.runTimer;
                    stepSystem.curClips = stepSystem.rockClipsR;
                }
                stepSystem.PlayerStepSound();
            }
        }


        if (playerStatus.isCrouch)
        {
            characterController.center = new Vector3(0, 0.5f, 0);
            characterController.height = 1f;
            headTrans.localPosition = Vector3.MoveTowards(headTrans.localPosition, new Vector3(0, 1, 0),Time.deltaTime*2.5f);
            
        }
        else
        {
            characterController.center = new Vector3(0, 0.9f, 0);
            characterController.height = 1.8f;
            headTrans.localPosition = Vector3.MoveTowards(headTrans.localPosition, new Vector3(0, 1.5f, 0), Time.deltaTime*2.5f);
        }



    }

   

   

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(input.horziontal, input.vertical);
        targetDir.Normalize();

        curDir = Vector2.SmoothDamp(curDir, targetDir, ref curDirVelocity, moveSmoothTime,.5f,1);

        if (characterController.isGrounded)
            velocityY = 0f;

        velocityY += gravity * Time.deltaTime;



        if (playerStatus.isRun)
            curSpeed = runSpeed;
        else if (playerStatus.isCrouch)
            curSpeed = crouchSpeed;
        else
            curSpeed = walkSpeed;

        Vector3 velocity = (transform.forward * curDir.y + transform.right * curDir.x) * curSpeed + Vector3.up*velocityY;
        

        characterController.Move(velocity * Time.deltaTime);
    }


}
