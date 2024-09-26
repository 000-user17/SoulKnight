using UnityEngine;

public class PlayerControlInput
{
    public float hor;
    public float ver;
    public Vector2 WeaponAimPos;  // 武器瞄准的点，如果是根据鼠标走，则存入鼠标的坐标
    public bool isAttack;
}

public class InputController : AbstractController
{
    public PlayerControlInput input { get; protected set;}
    private Vector2 dir;
    protected override void OnInit()
    {
        base.OnInit();
        input = new PlayerControlInput();
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        // 获取角色的位置信息，并将武器的pos定为该方向
        input.hor = Input.GetAxisRaw("Horizontal");
        input.ver = Input.GetAxisRaw("Vertical");
        input.isAttack = Input.GetMouseButton(0); // 这个函数返回一个布尔值（true 或 false），用于检测鼠标左键是否被按下
        dir.Set(input.hor, input.ver);
        if (dir.magnitude != 0)
        {
            input.WeaponAimPos = dir;
        }
    }
}
