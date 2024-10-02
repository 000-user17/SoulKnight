using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Events;
using UnityEngine;

public class UnityTool
{
    private static UnityTool instance;
    public static UnityTool Instance
    {
        get{
            if (instance == null)
            {
                instance = new UnityTool();
            }
            return instance;
        }
    }

    public T GetComponentFromChildren<T>(GameObject obj, string name, bool isActive = false)
    {
        foreach (Transform t in obj.GetComponentsInChildren<Transform>(!isActive))
        {
            if (t.name == name)
            {
                return t.GetComponent<T>();
            }
        }
        return default(T);
    }

    public Transform GetTransformFromChildren(GameObject parent, string name, bool isActive = false)
    {
        foreach(Transform t in parent.GetComponentsInChildren<Transform>(!isActive))
        // 只获取激活的子对象
        {
            if (t.name == name)
            {
                return t;
            }
        }
        return null;
    }

    /* 判断类型是否与泛型类型一致 */
    public bool isGenericType(Type type, Type generic)
    {
        if (type == null || generic == null) return false;
        if (type.GetInterfaces().Any(isGeneric)) return false;
        while (type != null && type != typeof(object))
        {
            if (isGeneric(type)) return true;
            type = type.BaseType;
        }
        return false;

        bool isGeneric(Type type)
        {
            if (!type.IsGenericType) return false;
            if (type.GetGenericTypeDefinition() == generic) return true;
            return false;
        }
    }
}
