using UnityEngine;

public class IPlayerBullet : IBullet
{
    public IPlayerBullet(GameObject obj) : base(obj)
    {
        
    }

    protected override void OnInit()
    {
        base.OnInit();
        if (detection != null)
        {
            detection.AddTriggerListener(TriggerEvent.OnTriggerEnter, "Enemy", (obj) =>
            {
                Remove();
                // obj是action函数的参数，应该在调用的时候，也就是Invoke的时候传入
                OnHitEnemy(obj.GetComponent<Symbol>().m_Character as IEnemy);
            });
        }
    }

    protected virtual void OnHitEnemy(IEnemy enemy)
    {
        
    }
}
