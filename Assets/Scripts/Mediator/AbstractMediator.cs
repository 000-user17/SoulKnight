using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 中介类，起到控制器和调用控制器的中介作用。有时两个类之间有交互重叠时，用中介类
可以让代码看起来更简洁 */
public abstract class AbstractMediator
{

    public List<AbstractController> controllers;
    public List<AbstractSystem> systems;

    public AbstractMediator()
    {
        controllers = new List<AbstractController>();
        systems = new List<AbstractSystem>();
    }

    public void RegisterController(AbstractController controller)
    {
        controllers.Add(controller);
    }

    public void RegisterSystem(AbstractSystem system)
    {
        systems.Add(system);
    }

    public T GetController<T>() where T : AbstractController
    {
        foreach(AbstractController controller in controllers)
        {
            if (controller is T)
            {
                return controller as T;
            }
        }
        return default(T);
    }

    public T GetSystem<T>() where T : AbstractSystem
    {
        foreach(AbstractSystem system in systems)
        {
            if (system is T)
            {
                return system as T;
            }
        }
        return default(T);
    }
}
