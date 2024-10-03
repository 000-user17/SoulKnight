using UnityEngine;

public class KnightStateMachine : PlayerStateMachine
{
    public KnightStateMachine(IPlayer player) : base(player)
    {

    }

    public override void GameUpdate()
    {
        base.GameUpdate();

        if (moveDir.magnitude > 0)
        {
            SetState<WalkState>();
        }
        else{
            SetState<IdleState>();
        }

    }
}