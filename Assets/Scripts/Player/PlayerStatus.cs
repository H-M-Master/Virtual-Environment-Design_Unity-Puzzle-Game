using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Status",menuName ="Player/Status")]
public class PlayerStatus : ScriptableObject
{
    public bool isWalk;
    public bool isRun;
    public bool isPounch;
    public bool isCrouch;
}
