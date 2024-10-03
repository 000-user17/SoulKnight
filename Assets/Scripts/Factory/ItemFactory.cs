using System;
using UnityEngine;

public enum PlayerBulletType
{
    Bullet_5,
}

public class ItemFactory : Singleton<ItemFactory>
{
    private ItemFactory()
    {

    }

    public IPlayerBullet GetPlayerBullet(PlayerBulletType type)
    {
        GameObject obj = UnityEngine.Object.Instantiate(ResourcesFactory.Instance.GetBullet(type.ToString()));
        IPlayerBullet bullet = null;
        switch (type)
        {
            case PlayerBulletType.Bullet_5:
                bullet = new Bullet_5(obj);
                break;
        }
        return bullet;
    }

    public Item GetEffect<T>() where T : Item
    {
        /*Activator.CreateInstance(typeof(T), new object[] { obj })：

        这段代码使用 Activator.CreateInstance 方法通过 反射 创建类型 T 的实例，并传递一个参数 obj 给该实例的构造函数。

        typeof(T)：获取泛型 T 的类型信息，在运行时反射出这个类型。

        new object[] { obj }：这是传递给构造函数的参数数组。在这种情况下，obj 是需要传递给 T 类型构造函数的一个参数。数组 new object[] 允许你传递多个参数给构造函数（即使只有一个参数时也要用数组包装）。
        说明：Activator.CreateInstance 会根据提供的参数匹配一个合适的构造函数，并调用它。这里构造函数期望有一个参数，类型为 obj 的类型。
        (T)：
        这里通过强制类型转换 (T)，将 Activator.CreateInstance 创建的对象（返回类型为 object）转换为泛型类型 T。这一步是必要的，因为 Activator.CreateInstance 返回的是 object 类型，你需要将其转换为你期望的类型。
        Item effect：

        最终创建的对象 effect 是一个 Item 类型（T 类型）的实例，它是通过调用 T 的构造函数并传入 obj 参数生成的。*/
        GameObject obj = UnityEngine.Object.Instantiate(ResourcesFactory.Instance.GetEffect(typeof(T).Name));
        Item effect = (T)Activator.CreateInstance(typeof(T), new object[] {obj});
        
        return effect;
    } 
}