using UnityEngine;
using System.Collections.Generic;
[System.Serializable]

// 这里更改了要重启unity项目才能正常
public class PlayerShareAttr : CharacterShareAttr
{
    // 注意，这里的变量名一定要和csv文件的第一行的名称匹配
    public PlayerType PlayerType;
    public PlayerWeaponType IdleWeapon;  // 默认武器
    public int Armor;  // 护甲
    public int Magic;  // 法力值
    public int Critical;  // 暴击
    public int HandAttackDamage;  // 手刀伤害
    public float FightingSpeed; // 开始战斗的移动速度
    public float FinishFightingSpeed; // 结束战斗的移动速度
    public float ArmorRecoveryTime; // 护甲恢复事件
    public float HurtArmorRecoveryTime;  // 受到伤害后多长时间开始恢复护甲
    public float HurtInvincibleTime; // 每次受到伤害的无敌时间

    public PlayerShareAttr()
    {

    }
}
