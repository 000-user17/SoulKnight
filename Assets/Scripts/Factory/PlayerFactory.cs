using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerType
{
    Knight
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
                Debug.Log(player);
                break;
        }
        return player;
    }
}
