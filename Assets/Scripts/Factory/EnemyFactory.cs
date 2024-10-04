using UnityEngine;

public class EnemyFactory : Singleton<EnemyFactory>
{
    private EnemyFactory()
    {

    }

    public IEnemy GetEnemy(EnemyType type)
    {
        GameObject obj = ResourcesFactory.Instance.GetEnemy(type.ToString());
        IEnemy enemy = CreateEnemy(type, obj);
        enemy.SetAttr(AttributeFactory.Instance.GetEnemyAttribute(type));
        return enemy;
    }

    private IEnemy CreateEnemy(EnemyType type, GameObject obj)
    {
        IEnemy enemy = null;
        switch (type)
        {
            case EnemyType.Stake:
                enemy = new Stake(obj);
                break;
        }
        return enemy;
    }

    public IEnemy GetEnemy(EnemyType type, GameObject obj)
    {
        return CreateEnemy(type, obj);
    }
}