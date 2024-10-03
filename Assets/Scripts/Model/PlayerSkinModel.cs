using System.Collections.Generic;

/* 存储皮肤数据 */
public class PlayerSkinModel : AbstractModel
{
    public List<PlayerSkinShareAttr> datas;
    protected override void OnInit()
    {
        base.OnInit();
        datas = ResourcesFactory.Instance.GetScripttableObject<PlayerSkinScriptableObject>().attrs;
    }
}
