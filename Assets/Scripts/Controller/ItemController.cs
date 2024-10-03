using System.Collections.Generic;
using UnityEngine;

public class ItemController : AbstractController
{
    private List<Item> items;

    public ItemController()
    {
        items = new List<Item>();
    }
    protected override void OnInit()
    {
        base.OnInit();
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        for (int i = 0; i < items.Count; ++i)
        {
            if (items[i].IsAlreadyRemove)
            {
                items.RemoveAt(i);
            }
            else{
                items[i].GameUpdate();
            }

        }
    }

    /* 把子弹添加到控制器 */
    public void AddToController(Item item)
    {
        items.Add(item);
        item.OnEnter();
    }

}
