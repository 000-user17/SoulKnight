using UnityEngine;

public class IEffectBoom : Item{
    public IEffectBoom(GameObject obj) : base(obj)
    {

    }

    protected override void OnExit()
    {
        base.OnExit();
        Object.Destroy(gameObject);
    }
}