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

    public T GetComponentFromChildren<T>(GameObject obj, string name)
    {
        foreach (Transform t in obj.GetComponentsInChildren<Transform>())
        {
            if (t.name == name)
            {
                return t.GetComponent<T>();
            }
        }
        return default(T);
    }
}
