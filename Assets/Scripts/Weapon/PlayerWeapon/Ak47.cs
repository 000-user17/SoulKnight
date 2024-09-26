using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : IPlayerWeapon
{
    public Ak47(GameObject obj, ICharacter character) : base(obj, character)
    {

    }

    protected override void OnFire()
    {
        base.OnFire();
    }
}
