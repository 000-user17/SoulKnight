using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 享元模式处理数据 */
public class ModelContainer
{
    private static ModelContainer instance;
    
    public static ModelContainer Instance
    {
        get{
            if (instance == null)
            {
                instance = new ModelContainer();
            }
            return instance;
        }
    }

    private Dictionary<Type, AbstractModel> modelDic;
    private ModelContainer()
    {
        modelDic = new Dictionary<Type, AbstractModel>();
        AddModel(new SceneModel());
        AddModel(new PlayerModel());
        AddModel(new PlayerSkinModel());
        AddModel(new WeaponModel());
        AddModel(new EnemyModel());
    }
    public T GetModel<T>() where T : AbstractModel
    {
        if (modelDic.ContainsKey(typeof(T)))
        {
            return modelDic[typeof(T)] as T;
        }
        return default(T);
    }

    private void AddModel<T> (T obj) where T : AbstractModel
    {
        modelDic.Add(typeof(T), obj as T);
    }
}
