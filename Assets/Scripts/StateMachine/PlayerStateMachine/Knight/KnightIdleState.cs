using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightIdleState : IPlayerState
{
    private float hor, ver;
    private Vector2 moveDir;
    public KnightIdleState(PlayerStateMachine machine) : base(machine)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();
        m_Animator.SetBool("isIdle", true); // 之前在unity动画的状态机界面设置的
        m_rb.velocity = Vector2.zero; // 将物体速度设置为0
    }

    protected override void OnUpdate()
    {
        // 这里不需要调用GameUpdate的原因是在父类IState中定定义了，并执行onUpload，直接继承该方法执行本方法
        base.OnUpdate();
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        moveDir.Set(hor, ver);
        if (moveDir.magnitude > 0) // 检查移动方向向量是否大于0，比如同时按下左右键
        {
            m_Machine.SetState<KnightWalkState>();
            return;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        m_Animator.SetBool("isIdle", false);
    }
}
