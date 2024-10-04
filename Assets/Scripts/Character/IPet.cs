using UnityEngine;

public class IPet : ICharacter
{
    protected IPetStateMachine m_StateMachine;
    public IPlayer Player { get; protected set;}
    public IPet(GameObject obj, IPlayer player) : base(obj)
    {
        m_Attr = AttributeFactory.Instance.GetPlayerAttribute(PlayerType.Knight);
        Player = player;
    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        m_StateMachine?.GameUpdate();
    }
}