using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class IPanel
{
    public GameObject gameObject { get; protected set;}

    public Transform transform => gameObject.transform;
    public RectTransform rectTransform { get; protected set;}
    protected IPanel parent;
    protected List<IPanel> children;
    private bool isInit;
    private bool isEnter;
    private bool isSuspend;
    private bool isShowAfterExit;
    
    public IPanel(IPanel panel)
    {
        parent = panel;
        children = new List<IPanel>();
    }

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        foreach(IPanel panel in children)
        {
            panel.GameUpdate();
        }
        if (!isSuspend)
        {
            OnUpdate();
        }
    }

    // 生命周期只执行一次
    protected virtual void OnInit()
    {
        Suspend();
        if (gameObject == null)
        {
            gameObject = GameObject.Find(GetType().Name);
        }
        rectTransform = gameObject.GetComponent<RectTransform>();
    }
    // 进入时显示
    protected virtual void OnEnter() {}
    // 非暂停状态时执行
    protected virtual void OnUpdate() 
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }
    // 面板退回时执行
    protected virtual void OnExit() 
    {
        if (!isShowAfterExit)
        {
            gameObject.SetActive(false);
        }
        parent.isEnter = false;
        parent.Resume();
        Suspend();

    }

    public void EnterPanel<T>() where T : IPanel
    {
        IPanel panel = GetPanel<T>();
        panel.Resume();
        Suspend();
    }

    public T GetPanel<T>() where T : IPanel
    {
        return children.Where(x => x is T).ToArray()[0] as T;
    }

    public void Suspend()
    {
        isSuspend = true;
    }

    public void Resume()
    {
        isSuspend = false;
    }

}
