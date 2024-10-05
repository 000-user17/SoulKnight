using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AbstractController
{
    public List<IEnemy> enemies { get; protected set;}
    public EnemyController() {}
    protected override void OnInit()
    {
        base.OnInit();
        enemies = new List<IEnemy>();
        AddEnemy(EnemyType.Stake, GameObject.Find("Stake"));

    }

    protected override void OnAfterRunUpdate()
    {
        base.OnAfterRunUpdate();
        foreach (IEnemy enemy in enemies)
        {
            enemy.GameUpdate();
        }
    }

    public void AddEnemy(EnemyType type)
    {
        enemies.Add(EnemyFactory.Instance.GetEnemy(type));
    }

    public void AddEnemy(EnemyType type, GameObject obj)
    {
        enemies.Add(EnemyFactory.Instance.GetEnemy(type, obj));
    }
}