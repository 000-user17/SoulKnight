using UnityEngine;
using System.Collections.Generic;
[System.Serializable]

// 这里更改了要重启unity项目才能正常
public class PlayerSkinShareAttr
{
    // 注意，这里的变量名一定要和csv文件的第一行的名称匹配
    public PlayerType PlayerType;
    public List<PlayerSkinType> PlayerSkinTypes;

    public PlayerSkinShareAttr()
    {

    }
}
