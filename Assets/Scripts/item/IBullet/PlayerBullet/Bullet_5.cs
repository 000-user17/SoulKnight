using System;
using UnityEngine;

public class Bullet_5 : IPlayerBullet
{
    public Bullet_5(GameObject obj) : base(obj)
    {
        
    }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();
        Item effect = ItemFactory.Instance.GetEffect<EffectBoom>();
        effect.SetPosition(transform.position);
        effect.AddToController();
    }

    protected override void OnHitEnemy(IEnemy enemy)
    {
        base.OnHitEnemy(enemy);
        enemy.UnderAttack(5);
        Item effect = ItemFactory.Instance.GetEffect<EffectBoom>();
        effect.SetPosition(transform.position);
        effect.AddToController();
    }

    public static implicit operator Bullet_5(Bullet_35 v)
    {
        throw new NotImplementedException();
    }
}
