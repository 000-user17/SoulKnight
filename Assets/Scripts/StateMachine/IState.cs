using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState
{
    private bool isInit;
    private bool isEnter;
    public IStateMachine m_Machine { get; protected set;}
    public IState(IStateMachine machine)
    {
        m_Machine = machine;
    }

    public virtual void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        OnUpdate();

    }

    protected virtual void OnInit() {}
    public virtual void OnEnter() {}

    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }
    public virtual void OnExit()
    {
        isEnter = false;
    }
}
