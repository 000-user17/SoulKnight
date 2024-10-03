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
}
