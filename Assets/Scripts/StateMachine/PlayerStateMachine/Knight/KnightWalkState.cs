using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightWalkState : IPlayerState
{
    private float hor, ver;
    private Vector2 moveDir;
    public KnightWalkState(PlayerStateMachine machine) : base(machine)
    {

    }

    protected override void OnUpdate()
    {
        /*
            ↑ Y
            |
            |
            |
            |
            +----→ X
            /
            /
            /
        Z
        */
        base.OnUpdate();
        /* Input.GetAxis("Horizontal")
        平滑输入：这个方法返回一个介于 -1 和 1 之间的值，通常用于处理如方向键或摇杆的输入。它会进行插值和平滑处理，使得输入更加平滑。
        延迟效果：当你按下或释放方向键时，输入值不会立即变化，而是会在一段时间内平滑过渡到目标值。
        即有一个加速度的启动，更真实 */
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        moveDir.Set(hor, ver);
        if (moveDir.magnitude > 0)
        {
            m_rb.transform.position += (Vector3) moveDir * 8 * Time.deltaTime;
        }
        else{
            m_Machine.SetState<RogueIdleState>();
            return;
        }

        if (hor > 0)
        {
            player.isLeft = false;
        }
        else if (hor < 0)
        {
            player.isLeft = true;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        m_Animator.SetBool("isIdle", true);
    }
    
}
