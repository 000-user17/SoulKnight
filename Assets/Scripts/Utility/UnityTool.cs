using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    private class ListInfo
    {
        public FieldInfo FieldInfo;
        public MethodInfo AddMethod;
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

    /* 把字符串转化为类型 */
    public object ConvertType(string s, Type type)
    {
        if (s == "TRUE")
        {
            return true;
        }
        if (s == "FALSE")
        {
            return false;
        }
        if (typeof(Enum).IsAssignableFrom(type))
        {
            return Enum.Parse(type, s);
        }
        return Convert.ChangeType(s, type);
    }

    /* 读取csv文件，并放入list中 */
    public void WriteDataToList<T>(List<T> list, TextAsset textAsset) where T : new()
    {
        if (textAsset == null) return;
        list.Clear();
        // 将 TextAsset 中的文本内容读取出来并去除 \r 回车符（这是因为某些文本文件在Windows中使用的换行符是 \r\n，为了处理跨平台兼容性，可能会去掉 \r）
        string text = textAsset.text.Replace("\r", "");
        string[] rows = text.Split("\n");
        if (rows.Length < 2) return;
        string[] fieldNames = rows[0].Split(",");
        Type t = typeof(T);

        // 反射读取列表
        Dictionary<string, ListInfo> fieldNameDic = new Dictionary<string, ListInfo>();  // 字段缓存一样的fieldName类型的ListInfo
        List<ListInfo> listInfos = new List<ListInfo>();
        foreach (string fieldName in fieldNames)
        {
            FieldInfo info = t.GetField(fieldName);  // 字段属性，即第一行的那些字段

            // 检查 info 是否为 null
            if (info == null)
            {
                Debug.LogError($"Field '{fieldName}' not found in type '{t.Name}'.");
            }
            // 如果字段类型是List类型，则处理
            if (typeof(IList).IsAssignableFrom(info.FieldType))
            {
                if (!fieldNameDic.ContainsKey(fieldName))
                {
                    ListInfo listInfo = new ListInfo();
                    listInfo.FieldInfo = info;
                    listInfo.AddMethod = info.FieldType.GetMethod("Add");
                    listInfos.Add(listInfo);
                    fieldNameDic.Add(fieldName, listInfo);

                }
            }

        }

        for (int i = 1; i < rows.Length; ++i)
        {
            if (rows[i] == "") continue;  // 跳过空行
            string[] colums = rows[i].Split(",");
            T obj = (T)Activator.CreateInstance(t);  // 如果是hero，则表示一个hero对象，后面的代码是在这里面设置属性和列表内容

            foreach (ListInfo info in listInfos)
            {
                /*
                info.FieldInfo: 表示 obj 对象中的某个字段，类型为 FieldInfo。这是通过反射获取的字段信息。
                info.FieldInfo.FieldType.GenericTypeArguments: 这段代码获取字段类型的泛型参数。假设该字段是一个泛型列表（例如 List<SomeType>），GenericTypeArguments 会返回 SomeType。
                typeof(List<>).MakeGenericType(...): 这部分代码使用 MakeGenericType 方法动态创建一个 List<SomeType> 类型。typeof(List<>) 表示泛型列表的类型，而 MakeGenericType 用于指定具体的类型参数。
                Activator.CreateInstance(...): 使用此方法创建一个新的列表实例。例如，如果字段类型是 List<int>，则这行代码会创建一个 List<int> 的实例。
                info.FieldInfo.SetValue(obj, ...): 将新创建的列表实例赋值给 obj 对象中对应的字段。
                */
                info.FieldInfo.SetValue(obj, Activator.CreateInstance(typeof(List<>).MakeGenericType(info.FieldInfo.FieldType.GenericTypeArguments)));
            }

            for (int j = 0; j < colums.Length; ++j)
            {
                FieldInfo fieldInfo = t.GetField(fieldNames[j]);
                if (colums[j] == "" || fieldInfo == null)
                {
                    continue;
                }
                
                if (typeof(IList).IsAssignableFrom(fieldInfo.FieldType))
                {
                    ListInfo listInfo = fieldNameDic[fieldNames[j]];
                    if (listInfo != null)
                    {
                        /*
                        fieldInfo.FieldType.GenericTypeArguments[0]: 这里的 [0] 访问的是该泛型类型参数数组的第一个元素。
                        如果字段是一个 List<T>，则 GenericTypeArguments[0] 就是 T 的具体类型。例如，对于字段类型 List<int>，GenericTypeArguments[0] 将是 int。
                        如果字段是一个更复杂的泛型类型，如 Dictionary<TKey, TValue>，那么 GenericTypeArguments[0] 将是 TKey 的类型，而 GenericTypeArguments[1] 将是 TValue 的类型。
                        */
                        listInfo.AddMethod.Invoke(fieldInfo.GetValue(obj), new object[] {ConvertType(colums[j], fieldInfo.FieldType.GenericTypeArguments[0])});
                    }
                }
                else
                {
                    fieldInfo.SetValue(obj, ConvertType(colums[j], fieldInfo.FieldType));
                }
            }
            list.Add(obj);
        }
    }
}
