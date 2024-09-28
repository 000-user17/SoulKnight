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
        modelDic.Add(typeof(SceneModel), new SceneModel());
    }
    public T GetModel<T>() where T : AbstractModel
    {
        if (modelDic.ContainsKey(typeof(T)))
        {
            return modelDic[typeof(T)] as T;
        }
        return default(T);
    }
}
