public class AttributeFactor : Singleton<AttributeFactor>
{
    private AttributeFactor()
    {

    }

    public PlayerAttribute GetPlayerAttribute(PlayerType type)
    {
        return new PlayerAttribute(PlayerCommand.Instance.GetPlayersShareAttr(type));
    }
}
