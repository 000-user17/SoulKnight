using Unity.VisualScripting;
using UnityEngine;

public class IBullet : Item
{
    protected TriggerDetection detection;
    public IBullet(GameObject obj) : base(obj)
    {
        
    }

    protected override void OnInit()
    {
        base.OnInit();
        detection = gameObject.GetComponent<TriggerDetection>();
        if (detection != null)
        {
            detection.AddTriggerListener(TriggerEvent.OnTriggerEnter, "Obstacle", (obj) =>
            {
                Remove();
                OnHitObstacle();
            });
        }
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.position += rotation * Vector2.right * 30 * Time.deltaTime;
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
