using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeapon
{
    public GameObject gameObject { get; protected set;}
    public Transform transform => gameObject.transform;
    protected ICharacter m_Character;
    private bool isInit;
    private bool isEnter;

    public IWeapon(GameObject obj, ICharacter character)
    {
        // 赋值之后再执行init()
        gameObject = obj;
        m_Character = character;
    }

    protected virtual void OnInit()
    {

    }
    protected virtual void OnEnter() // 切换至此武器时执行一次
    {}
    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }
    protected virtual void OnFire() // 发射时执行一次
    {}
    public virtual void onExit()
    {
        isEnter = false;
    }
    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        OnUpdate();
    }
}
