using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    public PlayerIdleState(PlayerStateMachine machine) : base(machine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (m_Animator == null) {
            return;
        }
        m_Animator.SetBool("isIdle", true); // 之前在unity动画的状态机界面设置的
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
        m_Animator.SetBool("isIdle", false);
    }
}
