using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : IPlayerWeapon
{
    public Ak47(GameObject obj, ICharacter character) : base(obj, character)
    {
        m_Attr = WeaponCommand.Instance.GetPlayerWeaponShareAttr(PlayerWeaponType.Ak47);
    }

    protected override void OnFire()
    {
        base.OnFire();
        Bullet_35 bullet = ItemFactory.Instance.GetPlayerBullet<Bullet_35>(PlayerBulletType.Bullet_35);
        bullet.SetPosition(FirePoint.transform.position);
        bullet.SetRotation(RotOrigin.transform.rotation); // 与武器朝向一致
        bullet.AddToController();
    }
}
