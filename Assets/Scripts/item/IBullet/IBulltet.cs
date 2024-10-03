using UnityEngine;

public class IBullet : Item
{
    public IBullet(GameObject obj) : base(obj)
    {
        
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.position += rotation * Vector2.right * 30 * Time.deltaTime;
        if (Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Obstacle")))
        {
            Remove();
            OnHitObstacle();
        }
    }

    protected virtual void OnHitObstacle()
    {

    }

    protected override void OnExit()
    {
        base.OnExit();
        Object.Destroy(gameObject);
    }
}
