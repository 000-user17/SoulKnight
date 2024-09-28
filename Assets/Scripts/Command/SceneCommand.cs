using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 修改与访问场景数据 */
public class SceneCommand : Singleton<SceneCommand>
{
    private SceneModel model;
    private AsyncOperation op;
    private SceneCommand()
    {
        model = ModelContainer.Instance.GetModel<SceneModel>();
    }

    public SceneName GetActiveSceneName()
    {
        return model.m_SceneName;
    }

    public int GetActiveSceneIndex()
    {
        return model.SceneIndex;
    }

    public int GetSceneIndex(SceneName name)
    {
        int ret = 0;
        switch (name)
        {
            case SceneName.MainMenuScene:
                ret = 0;
                break;
            case SceneName.MiddleScene:
                ret = 1;
                break;
            case SceneName.BattleScene:
                ret = 2;
                break;
        }
        return ret;
    }

    public void LoadScene(SceneName name)
    {
        op = SceneManager.LoadSceneAsync(GetSceneIndex(name));
        op.completed += OnSceneChangeComplete;
    }

    private void OnSceneChangeComplete(AsyncOperation op)
    {
        model.SetDate();
    }

}
