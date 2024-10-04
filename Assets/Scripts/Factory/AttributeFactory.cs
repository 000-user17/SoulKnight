public class AttributeFactory : Singleton<AttributeFactory>
{
    private AttributeFactory()
    {

    }

    public PlayerAttribute GetPlayerAttribute(PlayerType type)
    {
        return new PlayerAttribute(PlayerCommand.Instance.GetPlayersShareAttr(type));
    }

    public EnemyAttribute GetEnemyAttribute(EnemyType type)
    {
        return new EnemyAttribute(EnemyCommand.Instance.GetShareAttr(type));
    }
}
