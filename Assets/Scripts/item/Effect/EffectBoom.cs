using System.Threading;
using UnityEngine;

public class EffectBoom : IEffectBoom
{
    private Animator m_Animator;
    private AnimatorStateInfo animatorStateInfo;
    private float Timer;
    public EffectBoom(GameObject obj) : base(obj)
    {

    }

    protected override void OnInit()
    {
        base.OnInit();
        m_Animator = transform.Find("Sprite").GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Timer = 0;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        // 动画播放完成隐藏
        if (m_Animator.gameObject.activeSelf)
        {
            /*0 表示 动画层的索引。在 Unity 的动画系统中，动画可以分成不同的层。
            通常，默认的动画层是第 0 层，所以这里是获取第 0 层的当前动画状态。如果你有多个层，你可以指定其他的索引来获取不同层的状态。*/
            animatorStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.normalizedTime > 1)
            {
                m_Animator.gameObject.SetActive(false);
            }
        }

        Timer += Time.deltaTime;
        if (Timer > 1)
        {
            Remove();
        }
    }
}