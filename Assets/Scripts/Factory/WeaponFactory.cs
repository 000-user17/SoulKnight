using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public enum PlayerWeaponType
{
    BadPistol,
}

public class WeaponFactory
{
    private static WeaponFactory instance;
    private IPlayerWeapon weapon;
    public static WeaponFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WeaponFactory();
            }
            return instance;
        }
    }
    private WeaponFactory() {}

    public IPlayerWeapon GetPlayerWeapon(PlayerWeaponType type, ICharacter character)
    {
        // 获取角色上的武器原点，将实例化的武器作为这个原点的子物体 （gunoriginpoint）
        Transform origin = UnityTool.Instance.GetTransformFromChildren(character.gameObject, "GunOriginPoint");
        GameObject obj = UnityEngine.Object.Instantiate(ResourcesFactory.Instance.GetWeapon(type.ToString()), origin);
        obj.name = type.ToString();
        obj.transform.localPosition = Vector3.zero;
        switch (type)
        {
            case PlayerWeaponType.BadPistol:
                weapon = new BadPistol(obj, character);
                break;
        }
        return weapon;
    }

}
