public class EnemyCommand : Singleton<EnemyCommand>
{
    private EnemyModel model;
    private EnemyCommand()
    {

    }

    public EnemyShareAttr GetShareAttr(EnemyType type)
    {
        return model.datas.Find(data => data.EnemyType == type); // 没有找到返回null
    }
}