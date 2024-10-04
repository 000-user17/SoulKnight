using Pathfinding;
using UnityEngine;

public class IPetState : IState
{
    protected IPet m_Pet;
    protected IPlayer player;
    protected Transform transform => m_Pet.transform;
    protected Animator m_Animator;
    protected Seeker m_Seeker; // 寻路路径
    protected Path m_Path; //当前路径
    public IPetState(IPetStateMachine machine) : base(machine)
    {
        
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_Pet = (m_Machine as IPetStateMachine).m_Pet;
        player = m_Pet.Player;
        m_Animator = transform.GetComponent<Animator>();
        m_Seeker = transform.GetComponent<Seeker>();
    }
}