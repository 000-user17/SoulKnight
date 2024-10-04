/* 修改与访问角色数据 */
using System.Collections.Generic;

public class PlayerCommand : Singleton<PlayerCommand>
{
    private PlayerModel playerModel;
    private PlayerSkinModel skinModel;
    private PlayerCommand()
    {
        playerModel = ModelContainer.Instance.GetModel<PlayerModel>();
        skinModel = ModelContainer.Instance.GetModel<PlayerSkinModel>();
    }

    public PlayerShareAttr GetPlayersShareAttr(PlayerType type)
    {
        foreach (PlayerShareAttr attr in playerModel.data)
        {
            if (attr.PlayerType == type)
            {
                return attr;
            }
        }
        return null;
    }

    public List<PlayerSkinType> GetPlayerSkins(PlayerType type)
    {
        foreach (PlayerSkinShareAttr attr in skinModel.datas)
        {
            if (attr.PlayerType == type)
            {
                attr.PlayerSkinTypes.Remove(PlayerSkinType.None);
                return attr.PlayerSkinTypes;
            }
        }
        return null;
    }

}
