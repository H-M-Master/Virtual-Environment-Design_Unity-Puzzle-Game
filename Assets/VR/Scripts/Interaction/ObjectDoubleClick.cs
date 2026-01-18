using UnityEngine;

public class ObjectDoubleClick : GazeBase
{
    private float _prevouseClick;

    protected virtual void Start()
    {
        _prevouseClick = Time.realtimeSinceStartup;
    }

    private void OnMouseDown()
    {
        if ((Time.realtimeSinceStartup - _prevouseClick) < 0.3f)
        {
            //Debug.Log("双击");
            DoSomething();
        }
        else
        {
            _prevouseClick = Time.realtimeSinceStartup;
        }
    }

    protected virtual void DoSomething()
    {
    }
    public override void GazeToDo()
    {
        base.GazeToDo();
        DoSomething();
    }
}