public class WeaponCommand : Singleton<WeaponCommand>
{
    private WeaponModel weaponModel;
    private WeaponCommand()
    {
        weaponModel = ModelContainer.Instance.GetModel<WeaponModel>();
    }

    public PlayerWeaponShareAttr GetPlayerWeaponShareAttr(PlayerWeaponType type)
    {
        foreach (PlayerWeaponShareAttr attr in weaponModel.PlayerWeaponData)
        {
            if (attr.Type == type)
            {
                return attr;
            }
        }
        return null;
    }
}