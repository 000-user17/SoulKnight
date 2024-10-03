using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerWeaponData", menuName = "ScriptableObjects/playerWeaponData")]
public class PlayerWeaponScriptableObject : ScriptableObject
{
    public TextAsset textAsset;
    public List<PlayerWeaponShareAttr> attrs = new List<PlayerWeaponShareAttr>();
    private void OnValidate()
    {
        UnityTool.Instance.WriteDataToList(attrs, textAsset);
    }
}