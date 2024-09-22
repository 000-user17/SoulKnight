using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 挂载该类的物体，可以识别角色类 */
public class Symbol : MonoBehaviour
{
    public ICharacter m_Character { get; protected set;}
    public void SetCharacter(ICharacter character)
    {
        m_Character = character;
    }
}
