using UnityEngine;

/* 玩家武器 */
public class IPlayerWeapon : IWeapon
{
    public new IPlayer m_Character { get => base.m_Character as IPlayer; set => base.m_Character = value;}
    protected Transform RotOrigin;
    public PlayerWeaponShareAttr m_Attr;
    public bool isWeaponUsed;
    private bool isAttackKeyDown;
    private float FirecoolTime;
    private float FireTimer; // 武器发射冷却的计时器
    public IPlayerWeapon(GameObject obj, ICharacter character) : base(obj, character)
    {

    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        FireTimer += Time.deltaTime;
    }

    protected override void OnEnter()
    {
        base.OnEnter();
        FireTimer = FirecoolTime; // 切换到该武器的子弹第一颗可以直接发射
    }

    protected override void OnInit()
    {
        base.OnInit();
        RotOrigin = UnityTool.Instance.GetTransformFromChildren(gameObject, "RotOrigin");
        FirecoolTime = 1/ m_Attr.FireRate;
    }

    public void ControlWeapon(bool isAttack)
    {
        if (isAttack && FireTimer > FirecoolTime)
        {
            FireTimer = 0;
            OnFire();
        }
        // /* 必须连续点击才能不停放子弹，不然isAttackKeyDown等于按键，就不会一直放子弹 */
        // if (isAttackKeyDown != isAttack && isAttack)
        // {
        //     OnFire();
        // }
        // isAttackKeyDown = isAttack;
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
