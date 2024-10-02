using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueRollState : IPlayerState
{
    private float hor, ver;
    private float rollDuration = 0.25f; // 假设翻滚时间为0.5秒  
    private float rollTime = 0f; // 记录翻滚时间  
    private Vector2 moveDir;
    public RogueRollState(PlayerStateMachine machine) : base(machine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (m_Animator == null) {
            return;
        }
        m_Animator.SetBool("isRoll", true);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (player.recentDir.magnitude > 0)
        {
            m_rb.transform.position += (Vector3) player.recentDir * 12 * Time.deltaTime;
        }

        // 更新时间，检测翻滚是否结束  
        rollTime += Time.deltaTime;  
        if (rollTime >= rollDuration)  
        {
            rollTime = 0;
            m_Machine.SetState<RogueIdleState>(); // 翻滚结束后切换回空闲状态  
        }  
    }

    public override void OnExit()
    {
        base.OnExit();
        m_Animator.SetBool("isRoll", false);
    }
    
}
