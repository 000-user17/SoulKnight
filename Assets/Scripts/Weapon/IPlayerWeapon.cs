using UnityEngine;

/* 玩家武器 */
public class IPlayerWeapon : IWeapon
{
    public new IPlayer m_Character { get => base.m_Character as IPlayer; set => base.m_Character = value;}
    protected Transform RotOrigin;
    public bool isWeaponUsed;
    private bool isAttackKeyDown;
    public IPlayerWeapon(GameObject obj, ICharacter character) : base(obj, character)
    {

    }

    protected override void OnInit()
    {
        base.OnInit();
        RotOrigin = UnityTool.Instance.GetTransformFromChildren(gameObject, "RotOrigin");
    }

    public void ControlWeapon(bool isAttack)
    {
        /* 必须连续点击才能不停放子弹，不然isAttackKeyDown等于按键，就不会一直放子弹 */
        if (isAttackKeyDown != isAttack && isAttack)
        {
            OnFire();
        }
        isAttackKeyDown = isAttack;
    }

    public void RotateWeapon(Vector2 dir)
    {
        // 参数是武器朝向的向量
        float angle = 0;
        if (m_Character.isLeft)
        {
            angle = -Vector2.SignedAngle(Vector2.left, dir);
        }
        else
        {
            angle = Vector2.SignedAngle(Vector2.right, dir);
        }
        RotOrigin.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
