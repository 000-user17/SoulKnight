using System.Collections;
using UnityEngine;

public class PetFollowPlayerState : IPetState
{
    private int CurrentPathIndex;
    private float minDistance;
    private Vector3 moveDir;
    public PetFollowPlayerState(IPetStateMachine machine) : base(machine)
    {

    }

    protected override void OnInit()
    {
        base.OnInit();
        minDistance = 0.5f;
        CurrentPathIndex = 1;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        m_Animator.SetBool("isWalk", true);
        CoroutinePool.Instance.StartCoroutine(this, SeekerLoop());
    }

    private void MoveToTarget()
    {
        if (m_Path == null) return;
        if (CurrentPathIndex >= m_Path.vectorPath.Count) return; // 当前路径点走完了

        if (moveDir.x < -0.1)
        {
            m_Pet.isLeft = true;
        }
        else if (moveDir.x > 0.1)
        {
            m_Pet.isLeft = false;
        }

        moveDir = (m_Path.vectorPath[CurrentPathIndex] - transform.position).normalized;
        transform.position += moveDir * 7 * Time.deltaTime;

        if (Vector2.Distance(transform.position, m_Path.vectorPath[CurrentPathIndex]) < minDistance)
        {
            CurrentPathIndex += 1;
        }
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        MoveToTarget();
    }

    public override void OnExit()
    {
        base.OnExit();
        m_Animator.SetBool("isWalk", false);
        CoroutinePool.Instance.StopAllCoroutineInObject(this);
    }

    private IEnumerator SeekerLoop()
    {
        while (true)
        {
            if (m_Seeker.IsDone())
            {
                m_Seeker.StartPath(transform.position, player.transform.position, (p) =>
                {
                    m_Path = p;
                    CurrentPathIndex = 1;
                });
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

}