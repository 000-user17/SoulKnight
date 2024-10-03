[System.Serializable]

public class PlayerWeaponShareAttr : IWeaponShareAttr
{
    public PlayerWeaponType Type;  // 武器类型
    public WeaponCategory Category;  // 武器分类
    public QualityType Quality; // 武器品质
    public int Damage; // 武器伤害
    public int MagicSpend; // 蓝量消耗 
    public int CriticalRate; // 暴击率 0-100
    public int ScatteringRate; // 子弹轨迹偏移 0-100
    public int BaseAngle; // 弹道之间的夹角，只用于霰弹枪
    public float SpeedDecrease;  // 使用武器时减少的速度 0-1
}