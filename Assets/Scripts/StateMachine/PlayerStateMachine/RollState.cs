using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : IPlayerState
{
    private float rollDuration = 0.25f; // 假设翻滚时间为0.25秒  
    private float rollTime = 0f; // 记录翻滚时间  
    public RollState(PlayerStateMachine machine) : base(machine)
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

        m_rb.transform.position += (Vector3) player.recentDir * 16 * Time.deltaTime;

        // 更新时间，检测翻滚是否结束  
        rollTime += Time.deltaTime;  
        if (rollTime >= rollDuration)  
        {
            rollTime = 0;
        }  
    }

    public override void OnExit()
    {
        base.OnExit();
        m_Animator.SetBool("isRoll", false);
    }
    
}
