using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum PlayerType
{
    Knight,
    Rogue,
}

public class PlayerFactory
{
    private static PlayerFactory instance;

    public static PlayerFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerFactory();
            }
            return instance;
        }
    }

    public IPlayer GetPlayer(PlayerType type)
    {
        // 查找场景下的名为Knight的物体
        GameObject obj = GameObject.Find(type.ToString());

        IPlayer player = null;
        switch (type)
        {
            case PlayerType.Knight:
                player = new Knight(obj);
                break;
            case PlayerType.Rogue:
                player = new Rogue(obj);
                break;
        }

        if (!UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox"))
        {
            UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").AddComponent<Symbol>();
        }
        UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").SetCharacter(player);

        return player;
    }
}
