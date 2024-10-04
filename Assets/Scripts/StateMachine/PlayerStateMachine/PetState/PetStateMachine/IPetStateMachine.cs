using System.Numerics;
using UnityEngine;

public class IPetStateMachine : IStateMachine
{
    public IPet m_Pet { get; protected set;}
    public IPetStateMachine(IPet pet)
    {
        m_Pet = pet;
    }

    protected float GetDistanceToPlayer()
    {
        return UnityEngine.Vector2.Distance(m_Pet.transform.position, m_Pet.Player.transform.position);
    }

}