using UnityEngine;
using UnityEngine.UI;

public class SelectSkinInterface
{
    private PanelSelectPlayer panel;
    private GameObject gameObject;
    public SelectSkinInterface(PanelSelectPlayer panel, GameObject obj)
    {
        this.panel = panel;
        this.gameObject = obj;
    }

    public void OnInit()
    {
        UnityTool.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonLeft").onClick.AddListener(() =>
        {
            // panel.collider.transform.Find("Sprite").GetComponent<>
        });

        UnityTool.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonRight").onClick.AddListener(() =>
        {
            
        });
    }

    public void OnEnter()
    {

    }

    public bool isActive()
    {
        return gameObject.activeSelf;
    }
    
    public void ShowInterface()
    {
        gameObject.SetActive(true);
    }

    public void HideInterface()
    {
        gameObject.SetActive(false);
    }
}
