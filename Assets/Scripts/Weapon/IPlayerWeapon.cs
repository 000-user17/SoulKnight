using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 玩家武器 */
public class IPlayerWeapon : IWeapon
{
    public new IPlayer m_Character { get => base.m_Character as IPlayer; set => base.m_Character = value;}
    public IPlayerWeapon(GameObject obj, ICharacter character) : base(obj, character)
    {

    }
}
