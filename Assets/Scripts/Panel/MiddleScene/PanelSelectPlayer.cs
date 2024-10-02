using System.Collections;
using System.Collections.Generic;
using MiddleScene;
using UnityEngine;
using UnityEngine.UI;
using MiddleScene;
using System;
public class PanelSelectPlayer : IPanel
{
    private GameObject collider;
    public PanelSelectPlayer(IPanel panel) : base(panel)
    {
        children.Add(new PanelBattle(this));
    }

    protected override void OnInit()
    {
        base.OnInit();
        UnityTool.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack").onClick.AddListener(() =>
        {
            OnExit();
        });
        UnityTool.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonNext").onClick.AddListener(() =>
        {
            GameMediator.Instance.GetController<PlayerController>().SetMainPlayer(Enum.Parse<PlayerType>(collider.name));
            EventCenter.Instance.NotifyObserver(EventType.OnSelectPlayerFinish);
            gameObject.SetActive(false);
            EnterPanel<PanelBattle>();
        });
    }

    protected override void OnEnter()
    {
        base.OnEnter();
    }

    public void SetCollider(GameObject collider)
    {
        this.collider = collider;
    }
}
