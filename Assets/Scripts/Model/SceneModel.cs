using UnityEngine.SceneManagement;

public enum SceneName
{
    MainMenuScene,
    MiddleScene,
    BattleScene,
}
public class SceneModel : AbstractModel
{
    public SceneName m_SceneName;
    public int SceneIndex;
    protected override void OnInit()
    {
        base.OnInit();
        //SceneManager.GetActiveScene().buildIndex 返回的 buildIndex 是基于你在 Build Settings 窗口中添加场景的顺序来计数
        SetDate();
    }

    public void SetDate()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (SceneIndex)
        {
            case 0:
                m_SceneName = SceneName.MainMenuScene;
                break;
            case 1:
                m_SceneName = SceneName.MiddleScene;
                break;
            case 2:
                m_SceneName = SceneName.BattleScene;
                break;
        }
    }
}
