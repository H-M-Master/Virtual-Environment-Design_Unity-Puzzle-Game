using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : GazeBase
{
    public string SceneName;
    public override void GazeToDo()
    {
        base.GazeToDo();
        SceneManager.LoadScene(SceneName);
    }
}
