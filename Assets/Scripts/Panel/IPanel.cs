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
    private GameObject MainCanvas;
    
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
        MainCanvas = GameObject.Find("MainCanvas");
        if (gameObject == null)
        {
            // GameObject.Find() 方法会在场景中根据名字查找物体，而不是根据脚本的附加情况查找。
            // 代码 gameObject = GameObject.Find(GetType().Name); 实际上在寻找的是场景中名字和脚本类名相同的 GameObject，而不是挂载了该脚本的 GameObject。
            //gameObject = GameObject.Find(GetType().Name);

            // 如果object被隐藏，则需要下面的方式找
            // 前者 (GameObject.Find) 只能查找激活状态的对象，无法找到被隐藏的对象。
            // 后者 (GetTransformFromChildren) 能查找被隐藏的对象，因为它遍历的是所有子对象，无论这些子对象是否被禁用。
            gameObject = UnityTool.Instance.GetTransformFromChildren(MainCanvas, GetType().Name).gameObject;
        }
        rectTransform = gameObject.GetComponent<RectTransform>();
    }
    // 进入时显示
    protected virtual void OnEnter()
    {
        gameObject.SetActive(true);
    }
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
        gameObject.SetActive(true);
    }

}
