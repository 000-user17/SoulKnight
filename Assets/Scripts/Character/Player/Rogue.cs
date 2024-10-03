using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : IPlayer
{
    public Rogue(GameObject obj) : base(obj) {}
    protected override void OnInit()
    {
        base.OnInit();
        m_StateMachine = new RogueStateMachine(this);
    }
}
