using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacter
{
    public CharacterAttribute m_Attr { get; protected set;}
    public GameObject gameObject { get; protected set;}
    // Transform：管理该物体在空间中的位置、旋转、缩放，并且维护该物体与其子物体的层次结构。
    public Transform transform => gameObject.transform;

    private bool m_isLeft;
    private bool isInit;
    public Vector2 recentDir; // 上一时刻的方向
    private bool isStart;
    private bool isShouldRemove;
    private bool isAlreadyRemove;
    public bool isLeft
    {
        get => m_isLeft;
        set{
            if (value)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else{
                transform.rotation = Quaternion.identity;
            }
            m_isLeft = value;
        }
    }
    public ICharacter(GameObject obj)
    {
        gameObject = obj;
    }

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        OnCharacterUpdate();
    }

    protected virtual void OnInit() {}
    protected virtual void OnCharacterStart() {}
    protected virtual void OnCharacterUpdate()
    {
        if (!isStart)
        {
            isStart = true;
            OnCharacterStart();
        }
    }
    protected virtual void OnCharacterDieStart() {}

    protected virtual void Remove() 
    {
        isShouldRemove = true;
    }

    public void SetAttr(CharacterAttribute attr)
    {
        m_Attr = attr;
    }
}
