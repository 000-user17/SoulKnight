using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : IPlayer
{
    public Knight(GameObject obj) : base(obj) {}
    protected override void OnInit()
    {
        base.OnInit();
        m_StateMachine.SetState<KnightIdleState>(); // 初始状态设置为Idle状态
    }
}
