using UnityEngine;

public class LittleCool : IPet
{
    public LittleCool(GameObject obj, IPlayer player) : base(obj, player)
    {
        
    }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        m_StateMachine = new LittleCoolStateMachine(this);
    }
}