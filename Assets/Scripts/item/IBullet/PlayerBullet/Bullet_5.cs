using UnityEngine;

public class Bullet_5 : IPlayerBullet
{
    public Bullet_5(GameObject obj) : base(obj)
    {
        
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.position += rotation * Vector2.right * 30 * Time.deltaTime;
        if (Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Obstacle")))
        {
            Remove();
        }
    }
}
