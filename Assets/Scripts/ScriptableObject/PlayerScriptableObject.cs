using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/playerData")]
// 这里有时候更改了要重启unity项目才能正常
public class PlayerScriptableObject : ScriptableObject
{
    public TextAsset TextAsset;
    public List<PlayerShareAttr> attrs = new List<PlayerShareAttr>();

    /*在 Unity 中，OnValidate 是一个特殊的回调方法，它在脚本的属性发生变化时自动被调用。因此，该方法的名称是固定的，不能更改。

    关于 OnValidate 方法
    用途: OnValidate 方法通常用于对 ScriptableObject 或 MonoBehaviour 中的公共变量进行验证和初始化。每当在 Unity 编辑器中修改这些变量时，OnValidate 方法都会被自动调用。

    执行时机: 这个方法在编辑模式下调用，而不是在游戏运行时。因此，它适合用于编辑器中处理数据的有效性，或者更新 UI 等。*/
    private void OnValidate()
    {
        UnityTool.Instance.WriteDataToList(attrs, TextAsset);
    }
}
