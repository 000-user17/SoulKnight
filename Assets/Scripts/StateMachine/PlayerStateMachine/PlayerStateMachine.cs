using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : IStateMachine
{
    public IPlayer m_Player { get; protected set;}

    public PlayerStateMachine(IPlayer player) : base()
    {
        m_Player = player;
    }
}
