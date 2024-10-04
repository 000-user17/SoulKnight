using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class LittleCoolStateMachine : IPetStateMachine
{
    private float MaxDisToPlayer;
    private float MinDisToPlayer;
    public LittleCoolStateMachine(IPet pet) : base(pet)
    {
        MinDisToPlayer = 2;
        MaxDisToPlayer = 3;
    }

    public override void GameUpdate()
    {
        base.GameUpdate();
        if (currentState is PetIdleState)
        {
            if (GetDistanceToPlayer() > MaxDisToPlayer)
            {
                SetState<PetFollowPlayerState>();
            }
        }   
        else if (currentState is PetFollowPlayerState)
        {
            if (GetDistanceToPlayer() < MinDisToPlayer)
            {
                SetState<PetIdleState>();
            }
        }
        else if (currentState is null)
        {
            SetState<PetIdleState>();
        }
    }
}