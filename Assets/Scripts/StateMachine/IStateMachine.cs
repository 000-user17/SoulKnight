using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStateMachine
{
    private Dictionary<Type, IState> stateDic;
    private IState currentState;
    public IStateMachine()
    {
        stateDic = new Dictionary<Type, IState>(); // Type是类，IState是对象
    }
    public void SetState<T>()
    {
        if (!stateDic.ContainsKey(typeof(T)))
        {
            // 如果不存在该类，则用反射创建类对象
            stateDic.Add(typeof(T), (IState) Activator.CreateInstance(typeof(T), this));
        }
        stopCurrentState();
        currentState = stateDic[typeof(T)];
        currentState?.OnEnter();
    }

    public void stopCurrentState()
    {
        currentState?.OnExit();
    }

    public virtual void GameUpdate()
    {
        currentState?.GameUpdate();
    }
}
