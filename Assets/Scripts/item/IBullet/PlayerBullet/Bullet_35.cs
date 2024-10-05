using UnityEngine;

public class Bullet_35 : IPlayerBullet
{
    public Bullet_35(GameObject obj) : base(obj)
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
        enemy.UnderAttack(10);
        Item effect = ItemFactory.Instance.GetEffect<EffectBoom>();
        effect.SetPosition(transform.position);
        effect.AddToController();
    }
}
