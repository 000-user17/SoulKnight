using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/playerData")]
// 这里有时候更改了要重启unity项目才能正常
public class PlayerScriptableObject : ScriptableObject
{
    public List<PlayerShareAttr> attrs = new List<PlayerShareAttr>();
}
