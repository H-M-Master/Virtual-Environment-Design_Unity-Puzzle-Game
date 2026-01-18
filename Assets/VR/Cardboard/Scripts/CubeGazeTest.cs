using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGazeTest : GazeBase
{
    public override void GazeToDo()
    {
        TeleportRandomly();
    }
    public void TeleportRandomly()
    {
        Vector3 direction = Random.onUnitSphere;
        direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
        float distance = 2 * Random.value + 1.5f;
        transform.localPosition = direction * distance;
    }
}
