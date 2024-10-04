using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TriggerEvent
{
    OnTriggerEnter,
    OnTriggerExit,
    OnTriggerStay,
}

public class TriggerDetection : MonoBehaviour
{
    private Dictionary<GameObject, UnityAction<GameObject>> enterDic;
    private Dictionary<GameObject, UnityAction<GameObject>> exitDic;

    // 不确定是哪个物体，绑定物体的标签
    private Dictionary<string, UnityAction<GameObject>> enterTagDic; 
    private Dictionary<string, UnityAction<GameObject>> exitTagDic;

    private void Awake()
    {
        enterDic = new Dictionary<GameObject, UnityAction<GameObject>>();
        exitDic = new Dictionary<GameObject, UnityAction<GameObject>>();
        enterTagDic = new Dictionary<string, UnityAction<GameObject>>();
        exitTagDic = new Dictionary<string, UnityAction<GameObject>>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (enterDic.ContainsKey(collision.gameObject))
        {
            enterDic[collision.gameObject].Invoke(collision.gameObject);
        }
        if (enterTagDic.ContainsKey(collision.gameObject.tag))
        {
            enterTagDic[collision.gameObject.tag].Invoke(collision.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (exitDic.ContainsKey(collision.gameObject))
        {
            exitDic[collision.gameObject].Invoke(collision.gameObject);
        }
        if (exitTagDic.ContainsKey(collision.gameObject.tag))
        {
            exitTagDic[collision.gameObject.tag].Invoke(collision.gameObject);
        }
    }

    public void DicAddAction(Dictionary<GameObject, UnityAction<GameObject>> dic, GameObject target, UnityAction<GameObject> action)
    {
        if (!dic.ContainsKey(target))
        {
            dic.Add(target, action);
        }
        else
        {
            dic[target] += action;
        }
    }

    public void DicAddAction(Dictionary<string, UnityAction<GameObject>> dic, string target, UnityAction<GameObject> action)
    {
        if (!dic.ContainsKey(target))
        {
            dic.Add(target, action);
        }
        else
        {
            dic[target] += action;
        }
    }

    /*
    触发类型，触发目标物体，行为
    */
    public void AddTriggerListener(TriggerEvent type, GameObject target, UnityAction<GameObject> action)
    {
        switch(type)
        {
            case TriggerEvent.OnTriggerEnter:
                DicAddAction(enterDic, target, action);
                break;
            
            case TriggerEvent.OnTriggerExit:
                DicAddAction(exitDic, target, action);
                break;
        }
    }

    public void AddTriggerListener(TriggerEvent type, string targetTag, UnityAction<GameObject> action)
    {
        switch(type)
        {
            case TriggerEvent.OnTriggerEnter:
                DicAddAction(enterTagDic, targetTag, action);
                break;
            
            case TriggerEvent.OnTriggerExit:
                DicAddAction(exitTagDic, targetTag, action);
                break;
        }
    }
}
