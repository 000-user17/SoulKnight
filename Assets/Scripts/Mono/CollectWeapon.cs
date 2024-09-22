using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* 挂载到武器prefab上 */
public class CollectWeapon : MonoBehaviour
{
    private bool isPlayerEnter;
    private IPlayer player;
    private void Start()
    {

    }

    void Update()
    {
        if (isPlayerEnter)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // System.Enum.Parse<PlayerWeaponType>(name) 中的 name 实际上是 MonoBehaviour 类的一个字段，
                // 它指的是 GameObject 的 name 属性（即当前附加了 CollectWeapon 脚本的对象的名称）。
                // 由于 CollectWeapon 继承自 MonoBehaviour，因此 name 是隐式可用的。
                // 注意枚举名与武器名一致
                player.AddWeapon(System.Enum.Parse<PlayerWeaponType>(name));
                Object.Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
        {
            isPlayerEnter = true;
            player = collison.GetComponent<Symbol>().m_Character as IPlayer;
        }
    }

    private void OnTriggerExit2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
        {
            isPlayerEnter = false;
        }
    }
}
