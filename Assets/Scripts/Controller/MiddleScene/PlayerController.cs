using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AbstractController
{
    public IPlayer MainPlayer { get; protected set;}
    public PlayerController() {}
    protected override void OnInit()
    {
        base.OnInit();

    }

    protected override void OnAfterRunUpdate()
    {
        base.OnAfterRunUpdate();
        MainPlayer.GameUpdate();
    }

    public void SetMainPlayer(PlayerType type)
    {
        MainPlayer = PlayerFactory.Instance.GetPlayer(type);
        MainPlayer.SetPlayerControlInput(GameMediator.Instance.GetController<InputController>().input);

    }

}
