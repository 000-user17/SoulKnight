using System.Collections.Generic;

public class WeaponModel : AbstractModel
{
    public List<PlayerWeaponShareAttr> PlayerWeaponData;
    protected override void OnInit()
    {
        base.OnInit();
        PlayerWeaponData = ResourcesFactory.Instance.GetScripttableObject<PlayerWeaponScriptableObject>().attrs;
    }
}