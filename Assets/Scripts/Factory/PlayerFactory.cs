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

public enum PlayerSkinType
{
    None,
    Knight,
    Rogue,
    RogueKun,
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
        // 查找场景下的英雄物体
        GameObject obj = GameObject.Find(type.ToString());
        IPlayer player = GetPlayerObject(type, obj);

        if (!UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox"))
        {
            UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").AddComponent<Symbol>();
        }
        UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").SetCharacter(player);

        return player;
    }

    public IPlayer GetPlayer(PlayerShareAttr shareAttr)
    {
        GameObject obj = GameObject.Find(shareAttr.PlayerType.ToString());
        IPlayer player = GetPlayerObject(shareAttr.PlayerType, obj);
        player.SetAttr(AttributeFactor.Instance.GetPlayerAttribute(shareAttr.PlayerType));

        if (!UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox"))
        {
            UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").AddComponent<Symbol>();
        }
        UnityTool.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").SetCharacter(player);

        return player;
    }

    private IPlayer GetPlayerObject(PlayerType type, GameObject obj)
    {
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
        return player;
    }

    public IPet GetPlayerPet(PetType type, IPlayer player)
    {
        GameObject obj = GameObject.Find(type.ToString());
        IPet pet = GetPlayerPetObject(type, obj, player);
        return pet;
    }

    private IPet GetPlayerPetObject(PetType type, GameObject obj, IPlayer player)
    {
        IPet pet = null;
        switch  (type)
        {
            case PetType.LittleCool:
                pet = new LittleCool(obj, player);
                break;
        }
        return pet;
    }
}
