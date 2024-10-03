using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkinInterface
{
    private PanelSelectPlayer panel;
    private GameObject gameObject;
    private GameObject player;
    private List<PlayerSkinType> playerSkins;
    private int currentSkinIndex;
    public SelectSkinInterface(PanelSelectPlayer panel, GameObject obj)
    {
        this.panel = panel;
        this.gameObject = obj;
        playerSkins = new List<PlayerSkinType>();
    }

    public void OnInit()
    {
        UnityTool.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonLeft").onClick.AddListener(() =>
        {
            currentSkinIndex = currentSkinIndex - 1 < 0 ? playerSkins.Count - 1 : currentSkinIndex - 1;
            PlayerSkinType type = playerSkins[currentSkinIndex];
            if (type == PlayerSkinType.None) return;

            player.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                ResourcesFactory.Instance.GetPlayerSkin(type.ToString());
        });

        UnityTool.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonRight").onClick.AddListener(() =>
        {
            currentSkinIndex = (currentSkinIndex + 1) % playerSkins.Count;
            PlayerSkinType type = playerSkins[currentSkinIndex];
            if (type == PlayerSkinType.None) return;

            player.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                ResourcesFactory.Instance.GetPlayerSkin(type.ToString());
        });
    }

    public void OnEnter()
    {
        player = panel.collider.gameObject;
        playerSkins = PlayerCommand.Instance.GetPlayerSkins(System.Enum.Parse<PlayerType>(player.name));
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
