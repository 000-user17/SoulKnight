using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/playerData")]
// 这里有时候更改了要重启unity项目才能正常
public class PlayerScriptableObject : ScriptableObject
{
    public TextAsset TextAsset;
    public List<PlayerShareAttr> attrs = new List<PlayerShareAttr>();

    private void OnValidate()
    {
        UnityTool.Instance.WriteDataToList(attrs, TextAsset);
    }
}
