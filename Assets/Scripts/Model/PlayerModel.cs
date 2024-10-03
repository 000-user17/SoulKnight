

using System.Collections.Generic;

public class PlayerModel : AbstractModel
{
    public List<PlayerShareAttr> data;
    protected override void OnInit()
    {
        base.OnInit();
        data = ResourcesFactory.Instance.GetScripttableObject<PlayerScriptableObject>().attrs;
    }
}
