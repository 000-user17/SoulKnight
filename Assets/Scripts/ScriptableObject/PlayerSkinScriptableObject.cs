using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSkinData", menuName = "ScriptableObjects/playerSkinData")]
// 这里有时候更改了要重启unity项目才能正常
public class PlayerSkinScriptableObject : ScriptableObject
{
    public TextAsset textAsset;
    public List<PlayerSkinShareAttr> datas = new List<PlayerSkinShareAttr>();
    private void OnValidate()
    {
        UnityTool.Instance.WriteDataToList(datas, textAsset);
    }
}
