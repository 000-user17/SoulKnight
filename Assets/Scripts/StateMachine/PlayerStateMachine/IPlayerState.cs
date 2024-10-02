using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class IPlayerState : IState
{
    public new PlayerStateMachine m_Machine { get => base.m_Machine as PlayerStateMachine; set => base.m_Machine = value;}
    protected IPlayer player;
    protected GameObject gameObject; // 最终是在unity的各类角色上
    protected Rigidbody2D m_rb;
    protected Transform transform => gameObject.transform;
    protected Animator m_Animator;
    public IPlayerState(PlayerStateMachine machine) : base(machine)
    {

    }

    protected override void OnInit()
    {
        base.OnInit();
        player = m_Machine.m_Player;
        gameObject = player.gameObject;
        m_rb = transform.GetComponent<Rigidbody2D>();
        m_Animator = UnityTool.Instance.GetComponentFromChildren<Animator>(gameObject, "Sprite");
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}
