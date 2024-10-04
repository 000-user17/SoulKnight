using UnityEngine;

public class KnightStateMachine : PlayerStateMachine
{
    public KnightStateMachine(IPlayer player) : base(player)
    {
        SetState<PlayerIdleState>();
    }

    public override void GameUpdate()
    {
        base.GameUpdate();

        if (moveDir.magnitude > 0)
        {
            SetState<PlayerWalkState>();
        }
        else{
            SetState<PlayerIdleState>();
        }

    }
}