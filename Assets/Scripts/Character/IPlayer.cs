using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : ICharacter
{
    protected Animator m_Animator;
    protected PlayerStateMachine m_StateMachine;
    public IPlayer(GameObject obj) : base(obj) {}
    protected override void OnInit()
    {
        base.OnInit();
        m_StateMachine = new PlayerStateMachine(this);
        m_Animator = transform.Find("Sprite").GetComponent<Animator>();
    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        m_StateMachine.GameUpdate();
    }
}
