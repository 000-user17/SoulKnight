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
        Bullet_5 bullet = ItemFactory.Instance.GetPlayerBullet(PlayerBulletType.Bullet_5) as Bullet_5;
        bullet.SetPosition(FirePoint.transform.position);
        bullet.SetRotation(RotOrigin.transform.rotation); // 与武器朝向一致
        bullet.AddToController();
    }
}
