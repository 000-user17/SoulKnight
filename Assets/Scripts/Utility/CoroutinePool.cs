using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePool : MonoBehaviour
{
    private static CoroutinePool instance;
    public static CoroutinePool Instance
    {
        get{
            GameObject obj = GameObject.Find("CoroutinePool");
            if (obj == null)
            {
                obj = new GameObject("CoroutinePool");
                obj.AddComponent<CoroutinePool>();
            }
            return obj.GetComponent<CoroutinePool>();
        }
    }

    private Dictionary<object, List<Coroutine>> dic = new Dictionary<object, List<Coroutine>>();  // 一个对象可能有多个协程

    private void Start()
    {
        // 添加组件时，Start不会执行
    }

    public void StartCoroutine(object obj, IEnumerator coroutine)
    {
        if (dic.ContainsKey(obj))
        {
            dic[obj].Add(StartCoroutine(coroutine));
        }
        else
        {
            dic.Add(obj, new List<Coroutine>() {StartCoroutine(coroutine)});
        }
    }

    public void StopAllCoroutineInObject(object obj)
    {
        if (dic.ContainsKey(obj))
        {
            foreach (Coroutine c in dic[obj])
            {
                StopCoroutine(c);
            }
            dic[obj].Clear();
        }
    }
}