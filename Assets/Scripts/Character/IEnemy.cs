using UnityEngine;

public class IEnemy : ICharacter
{
    public new EnemyAttribute m_Attr { get => base.m_Attr as EnemyAttribute; set => base.m_Attr = value;}
    public IEnemy(GameObject obj) : base(obj)
    {

    }
}