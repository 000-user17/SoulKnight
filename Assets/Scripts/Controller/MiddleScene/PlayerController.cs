using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AbstractController
{
    public IPlayer MainPlayer { get; protected set;}
    protected List<IPet> pets;
    public PlayerController() {}
    protected override void OnInit()
    {
        base.OnInit();
        pets = new List<IPet>();

    }

    protected override void OnAfterRunUpdate()
    {
        base.OnAfterRunUpdate();
        MainPlayer.GameUpdate();
        foreach (IPet pet in pets)
        {
            pet.GameUpdate();
        }
    }

    public void SetMainPlayer(PlayerType type)
    {
        MainPlayer = PlayerFactory.Instance.GetPlayer(type);
        MainPlayer.SetPlayerControlInput(GameMediator.Instance.GetController<InputController>().input);

    }

    public void AddPlayerPet(PetType type, IPlayer player)
    {
        pets.Add(PlayerFactory.Instance.GetPlayerPet(type, player));
    }

}
