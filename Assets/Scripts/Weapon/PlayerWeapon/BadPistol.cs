using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPistol : IPlayerWeapon
{
    public BadPistol(GameObject obj, ICharacter character) : base(obj, character)
    {
        m_Attr = WeaponCommand.Instance.GetPlayerWeaponShareAttr(PlayerWeaponType.BadPistol);
    }

    protected override void OnFire()
    {
        base.OnFire();
        Bullet_5 bullet = ItemFactory.Instance.GetPlayerBullet<Bullet_5>(PlayerBulletType.Bullet_5);
        bullet.SetPosition(FirePoint.transform.position);
        bullet.SetRotation(RotOrigin.transform.rotation); // 与武器朝向一致
        bullet.AddToController();
    }
}
