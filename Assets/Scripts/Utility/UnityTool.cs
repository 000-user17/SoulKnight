using System.Collections;
using System.Collections.Generic;
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
}
