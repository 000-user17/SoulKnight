using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : AbstractController
{
    private IPanel rootPanel;
    public UIController() {}

    protected override void OnInit()
    {
        base.OnInit();
        switch(SceneCommand.Instance.GetActiveSceneName())
        {
            case SceneName.MainMenuScene:
                rootPanel = new MainMenuScene.PanelRoot();
                break;
            case SceneName.MiddleScene:
                rootPanel = new MiddleScene.PanelRoot();
                break;
        }
        
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        rootPanel.GameUpdate();
    }
}