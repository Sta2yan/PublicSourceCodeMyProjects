using System;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public event Action Started;
    public event Action Ended;

    public State Enter()
    {
        EnterLogic();
        Started?.Invoke();
        return this;
    }

    public void Exit()
    {
        ExitLogic();
        enabled = false;
        Ended?.Invoke();
    }

    protected virtual void EnterLogic() {}

    protected virtual void ExitLogic() {}
}
