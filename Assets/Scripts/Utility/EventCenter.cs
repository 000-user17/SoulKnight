using System.Collections.Generic;
using UnityEngine.Events;

public enum EventType{

}

/* 观察者模式事件中心 */
public class EventCenter
{
    public class IEventInfo
    {

    }

    // 无参事件
    public class EventInfo : IEventInfo
    {
        public UnityAction action;
        public EventInfo(UnityAction action)
        {
            this.action = action;
        }
    }

    // 带一个参数的事件
    public class EventInfo<T> : IEventInfo
    {
        // c#可以父类的引用指向子类的实例,但是反过来不行，所以这里要用UnityAction<T>不然其子类无法复制给UnityAction的引用
        public UnityAction<T> action;
        public EventInfo(UnityAction<T> action)
        {
            this.action = action;
        }
    }

    private Dictionary<EventType, List<IEventInfo>> EventDic;

    private EventCenter()
    {
        EventDic = new Dictionary<EventType, List<IEventInfo>>();
    }

    public void RegisterObserver(EventType type, UnityAction action)
    {
        if (!EventDic.ContainsKey(type))
        {
            EventDic.Add(type, new List<IEventInfo> {new EventInfo(action)});
        }
        else{
            //+= 语法用于将一个委托（在这里是 action）添加到另一个委托的调用链中。在 C# 中，委托可以被视为指向方法的引用。具体来说：
            // 类型转换：(EventDic[type] as EventInfo) 将字典中与 type 关联的值转换为 EventInfo 类型。
            // 委托组合：(EventDic[type] as EventInfo).action += action; 将新的 action 委托添加到现有的 action 委托中。这意味着，当事件被触发时，所有注册的回调（包括新的和旧的）都会被调用。
            foreach (IEventInfo info in EventDic[type])
            {
                if (info is EventInfo)
                {
                    (info as EventInfo).action += action;
                }
            }
        }
    }
    public void RegisterObserver<T>(EventType type, UnityAction<T> action)
    {
        if (!EventDic.ContainsKey(type))
        {
            EventDic.Add(type, new List<IEventInfo> {new EventInfo<T>(action)});
        }
        else{
            foreach (IEventInfo info in EventDic[type])
            {
                if (info is EventInfo<T>)
                {
                    (info as EventInfo<T>).action += action;
                }
            }
        }
    }

    public void NotifyObserver(EventType type)
    {
        if (EventDic.ContainsKey(type))
        {
            foreach (IEventInfo info in EventDic[type])
            {
                if (info is EventInfo)
                {
                    (info as EventInfo).action.Invoke();
                }
            }
        }
    }

    public void NotifyObserver<T>(EventType type, T param)
    {
        if (EventDic.ContainsKey(type))
        {
            foreach (IEventInfo info in EventDic[type])
            {
                if (info is EventInfo<T>)
                {
                    // action是RegisterObserver注册进去的，UnityAction<T> action 说明action委托有一个T类型的参数
                    (info as EventInfo<T>).action.Invoke(param);
                }
            }
        }
    }

    public void ClearObserver()
    {
        EventDic.Clear();
    }
}