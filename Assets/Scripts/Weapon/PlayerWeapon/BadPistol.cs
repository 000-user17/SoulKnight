using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPistol : IPlayerWeapon
{
    public BadPistol(GameObject obj, ICharacter character) : base(obj, character)
    {

    }

    protected override void OnFire()
    {
        base.OnFire();
    }
}
