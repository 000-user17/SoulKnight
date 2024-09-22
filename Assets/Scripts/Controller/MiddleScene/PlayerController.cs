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
        MainPlayer = PlayerFactory.Instance.GetPlayer(PlayerType.Knight);
    }
    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        MainPlayer.GameUpdate();
    }

}
