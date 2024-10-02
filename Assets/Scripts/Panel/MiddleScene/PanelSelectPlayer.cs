using System.Collections;
using System.Collections.Generic;
using MiddleScene;
using UnityEngine;
using UnityEngine.UI;
using MiddleScene;
using System;
public class PanelSelectPlayer : IPanel
{
    public GameObject collider { get; protected set;}
    private GameObject DivMain;
    private SelectSkinInterface SkinInterface;
    public PanelSelectPlayer(IPanel panel) : base(panel)
    {
        children.Add(new PanelBattle(this));
    }

    protected override void OnInit()
    {
        base.OnInit();
        SkinInterface = new SelectSkinInterface(this, UnityTool.Instance.GetTransformFromChildren(gameObject, "DivSkin").gameObject);
        SkinInterface.OnInit();
        SkinInterface.HideInterface();
        DivMain = UnityTool.Instance.GetTransformFromChildren(gameObject, "DivMain").gameObject;

        UnityTool.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack").onClick.AddListener(() =>
        {
            if (SkinInterface.isActive())
            {
                SkinInterface.HideInterface();
                DivMain.SetActive(true);
            }
            else
            {
                OnExit();
            }
        });
        UnityTool.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonNext").onClick.AddListener(() =>
        {
            // 先选择角色，后选择皮肤
            if (SkinInterface.isActive())
            {
                GameMediator.Instance.GetController<PlayerController>().SetMainPlayer(Enum.Parse<PlayerType>(collider.name));
                EventCenter.Instance.NotifyObserver(EventType.OnSelectPlayerFinish);
                gameObject.SetActive(false);
                EnterPanel<PanelBattle>();
            }
            else
            {
                SkinInterface.ShowInterface();
                DivMain.SetActive(false);
            }
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
