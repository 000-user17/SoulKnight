using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class ResourcesFactory
{
    private static ResourcesFactory instance;
    public static ResourcesFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ResourcesFactory();
            }
            return instance;
        }
    }
    private string WeaponPath = "Prefabs/Weapon/";
    private string PlayerSkinPath = "Animation/Characters/Players/";
    private string DataPath = "Datas/";
    private Dictionary<string, GameObject> objDic;
    private ResourcesFactory()
    {
        objDic = new Dictionary<string, GameObject>();
    }

    public GameObject GetWeapon(string name)
    {
        if (objDic.ContainsKey(WeaponPath + name))
        {
            return objDic[WeaponPath + name];
        }
        // 在 Unity 中，所有通过 Resources.Load 或 Resources.LoadAll 加载的资源必须位于项目的 Assets/Resources 文件夹下
        GameObject obj = Resources.LoadAll<GameObject>(WeaponPath).Where(x => x.name == name).ToArray()[0];
        objDic.Add(WeaponPath + name, obj);
        return obj;
    }

    public RuntimeAnimatorController GetPlayerSkin(string name)
    {
        return Resources.LoadAll<RuntimeAnimatorController>(PlayerSkinPath + name).Where(x => x.name == name).ToArray()[0];
    }

    /* 加载角色数据的方法 */
    public T GetScripttableObject<T>() where T : ScriptableObject
    {
        Type type = typeof(T);
        string path = DataPath;
        if (type == typeof(PlayerScriptableObject))
        {
            path += "PlayerData";
        }
        else if (type == typeof(PlayerSkinScriptableObject))
        {
            path += "PlayerSkinData";
        }
        return Resources.Load<T>(path);
    }

}
