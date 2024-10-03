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
        m_StateMachine = new KnightStateMachine(this);
    }
}
