using UnityEngine;

public abstract class CharacterAttribute
{
    public CharacterShareAttr m_ShareAttr{ get; protected set;}
    public float currentHp;
    public CharacterAttribute(CharacterShareAttr shareAttr)
    {
        m_ShareAttr = shareAttr;
    }
}
