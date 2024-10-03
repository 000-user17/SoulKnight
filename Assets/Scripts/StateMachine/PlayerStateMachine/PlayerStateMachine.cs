using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : IStateMachine
{
    public IPlayer m_Player { get; protected set;}
    protected float hor, ver;
    protected Vector2 moveDir;

    public PlayerStateMachine(IPlayer player) : base()
    {
        m_Player = player;
    }

    public override void GameUpdate()
    {
        base.GameUpdate();
        hor = Input.GetAxisRaw("Horizontal"); // 必须与walk状态对应，都为raw或都不是
        ver = Input.GetAxisRaw("Vertical");
        moveDir.Set(hor, ver);
    }

    public Vector2 GetMoveDir()
    {
        return moveDir;
    }
}
