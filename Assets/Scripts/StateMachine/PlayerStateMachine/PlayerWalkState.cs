using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : IPlayerState
{
    public PlayerWalkState(PlayerStateMachine machine) : base(machine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (m_Animator == null) {
            return;
        }
        m_Animator.SetBool("isWalk", true);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        
        Vector2 moveDir = m_Machine.GetMoveDir();
        player.recentDir = moveDir;

        if (moveDir.x > 0)
        {
            player.isLeft = false;
        }
        else if (moveDir.x < 0)
        {
            player.isLeft = true;
        }
        m_rb.transform.position += (Vector3) moveDir * player.m_Attr.m_ShareAttr.Speed * Time.deltaTime;
    }

    public override void OnExit()
    {
        base.OnExit();
        m_Animator.SetBool("isWalk", false);
    }
    
}
