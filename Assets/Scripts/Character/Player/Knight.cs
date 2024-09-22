using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : IPlayer
{
    protected Animator m_Animatior;
    private Vector2 moveDir;
    private float hor, ver;
    private Rigidbody2D m_rb;
    public Knight(GameObject obj) : base(obj) {}
    protected override void OnInit()
    {
        base.OnInit();
        m_rb = transform.GetComponent<Rigidbody2D>();
    }
    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        moveDir.Set(hor, ver);
        if (moveDir.magnitude > 0)
        {
            m_rb.transform.position += (Vector3) moveDir * 8 * Time.deltaTime;
        }
    }

}
