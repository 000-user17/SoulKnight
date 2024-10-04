using System.Collections.Generic;
using System.Data;

public class EnemyModel : AbstractModel
{
    public List<EnemyShareAttr> datas;
    protected override void OnInit()
    {
        base.OnInit();
        datas = ResourcesFactory.Instance.GetScripttableObject<EnemyScriptableObject>().attrs;
    }
}