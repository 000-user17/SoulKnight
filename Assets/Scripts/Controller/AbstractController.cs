using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 负责执行游戏的更新逻辑 */
public abstract class AbstractController
{
    private bool isRun;
    private bool isInit;
    private bool isBeforeRunStart;
    private bool isAfterRunStart;

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        if (!isRun)
        {
            OnBeforeRunUpdate();
        }
        else
        {
            OnAfterRunUpdate();
        }
        AlwaysUpdate();
    }

    protected virtual void OnInit() {}

    protected virtual void OnBeforeRunStart() {}

    protected virtual void OnBeforeRunUpdate() 
    {
        if (!isBeforeRunStart)
        {
            isBeforeRunStart = true;
            OnBeforeRunStart();
        }
    }

    protected virtual void OnAfterRunStart() {}

    protected virtual void OnAfterRunUpdate() 
    {
        if (!isAfterRunStart)
        {
            isAfterRunStart = true;
            OnBeforeRunStart();
        }
    }

    protected virtual void AlwaysUpdate() { }

    public void TurnOnController()
    {
        isRun = true;
    }

    public void TurnOffController()
    {
        isRun = false;
    }


}
