using UnityEngine;

public class RogueStateMachine : PlayerStateMachine
{
    private float rollDuration = 0.25f; // 假设翻滚时间为0.25秒  
    private float rollTime = 0f; // 记录翻滚时间  
    private bool isRoll;
    public RogueStateMachine(IPlayer player) : base(player)
    {
        SetState<IdleState>();
    }

    public override void GameUpdate()
    {
        base.GameUpdate();

        if (moveDir.magnitude > 0)
        {
            // 检测按下空格键或当前是否正在翻滚
            if (isRoll || Input.GetKeyDown(KeyCode.Space))
            {
                // 如果还没有进入翻滚状态，并且按下了空格键
                if (!isRoll && Input.GetKeyDown(KeyCode.Space))
                {
                    isRoll = true;  // 开始翻滚
                    rollTime = 0f;  // 重置翻滚时间
                }

                // 更新时间，检测翻滚是否结束  
                rollTime += Time.deltaTime;
                if (rollTime >= rollDuration)
                {
                    rollTime = 0;  // 重置翻滚时间
                    isRoll = false;  // 结束翻滚
                }
                else
                {
                    SetState<RollState>();  // 在翻滚期间设置状态为RollState
                    return;  // 跳过后续逻辑，继续翻滚
                }
            }

            SetState<WalkState>();  // 当不翻滚时，进入行走状态
        }
        else
        {
            SetState<IdleState>();  // 当没有移动时，进入Idle状态
        }
    }
}