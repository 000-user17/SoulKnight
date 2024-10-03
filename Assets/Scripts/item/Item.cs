using UnityEngine;

public class Item
{
    public GameObject gameObject { get; protected set;}
    public Transform transform => gameObject.transform;
    protected Vector2 position;
    protected Quaternion rotation;
    private bool isInit;
    private bool shouldBeRemove; // 是否应该移除
    public bool IsAlreadyRemove { get; protected set;} // 是否已经移除
    public Item(GameObject obj)
    {
        gameObject = obj;
    }

    public void GameUpdate()
    {
        OnUpdate();
        if (shouldBeRemove && !IsAlreadyRemove)
        {
            IsAlreadyRemove = true;
            OnExit();
        }
    }

    protected virtual void OnInit()
    {

    }

    /* 每次加入控制器的时候执行,比如每次加入控制器自动设置物体的位置 */
    public virtual void OnEnter()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        shouldBeRemove = false;
        IsAlreadyRemove = false;
    }

    protected virtual void OnUpdate()
    {

    }

    /* 从控制器移除前，比如销毁物体 */
    protected virtual void OnExit()
    {

    }

    public void Remove()
    {
        shouldBeRemove = true;
        IsAlreadyRemove = false;
    }

    public void SetPosition(Vector2 pos)
    {
        position = pos;
        transform.position = position;
    }

    public void SetRotation(Quaternion rot)
    {
        rotation = rot;
        transform.rotation = rotation;
    }

    public void AddToController()
    {
        GameMediator.Instance.GetController<ItemController>().AddToController(this);
    }

}
