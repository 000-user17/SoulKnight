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
    private string PlayerSkinPath = "Animation/Character/Players/";
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

}
