using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class IPlayer : ICharacter
{
    public new PlayerAttribute m_Attr { get => base.m_Attr as PlayerAttribute; set => base.m_Attr = value;}
    protected Animator m_Animator;
    protected PlayerStateMachine m_StateMachine;
    protected List<IPlayerWeapon> weapons;
    protected int weaponIdx;
    protected IPlayerWeapon currentWeapon;
    public PlayerControlInput input { get; protected set;}
    public IPlayer(GameObject obj) : base(obj) {}
    protected override void OnInit()
    {
        base.OnInit();
        weapons = new List<IPlayerWeapon>();
        m_Animator = transform.Find("Sprite").GetComponent<Animator>();
    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        m_StateMachine.GameUpdate();
        if (currentWeapon != null)
        {
            currentWeapon.GameUpdate();
            currentWeapon.ControlWeapon(input.isAttack);
            currentWeapon.RotateWeapon(input.WeaponAimPos);
            SwapWeaponAction();
        }
    }
    public void AddWeapon(PlayerWeaponType type)
    {
        IPlayerWeapon weapon = WeaponFactory.Instance.GetPlayerWeapon(type, this);
        weapons.Add(weapon);
        if (weapons.Count == 1)
        {
            UseWeapon(weapon);
        }
        else
        {
            weapon.gameObject.SetActive(false);
        }
        
    }

    public void SwapWeaponAction()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwapWeapon();
        }
    }

    public void SwapWeapon()
    {
        if (weapons.Count >= 2)
        {
            currentWeapon.onExit();
            currentWeapon.gameObject.SetActive(false);
            weaponIdx += 1;
            if (weaponIdx == weapons.Count)
            {
                weaponIdx = 0;
            }
            UseWeapon(weapons[weaponIdx]);
        }
    }

    public void UseWeapon(IPlayerWeapon weapon)
    {
        weapon.isWeaponUsed = true;
        weapon.gameObject.SetActive(true);
        currentWeapon = weapon;
    }

    public IPlayerWeapon GetUsedWeapon()
    {
        foreach(IPlayerWeapon weapon in weapons)
        {
            if (weapon.isWeaponUsed)
            {
                return weapon;
            }
        }
        return null;
    }

    public void SetPlayerControlInput(PlayerControlInput input)
    {
        this.input = input;
    }
}
