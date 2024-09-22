using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : ICharacter
{
    protected Animator m_Animator;
    public IPlayer(GameObject obj) : base(obj) {}
    protected override void OnInit()
    {
        base.OnInit();
        m_Animator = transform.Find("Sprite").GetComponent<Animator>();
    }
}
