using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MainMenuScene
{
    public class PanelRoot : IPanel
    {
        public PanelRoot() : base(null) {}

        protected override void OnInit()
        {
            base.OnInit();
            UnityTool.Instance.GetComponentFromChildren<Button>(gameObject,
                "ButtonStart").onClick.AddListener(() =>
                {
                    Debug.Log("游戏开始");
                });
        }
        protected override void OnEnter()
        {
            base.OnEnter();
        }

    }

}