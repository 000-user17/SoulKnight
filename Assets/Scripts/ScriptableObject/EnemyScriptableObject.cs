using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData")]
public  class EnemyScriptableObject : ScriptableObject
{
    public TextAsset textAsset;
    public List<EnemyShareAttr> attrs = new List<EnemyShareAttr>();
    private void OnValidate()
    {
        UnityTool.Instance.WriteDataToList(attrs, textAsset);
    }
}