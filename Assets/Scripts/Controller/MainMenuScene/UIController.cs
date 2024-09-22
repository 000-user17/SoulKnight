using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenuScene
{
    public class UIController : AbstractController
    {
        private PanelRoot rootPanel;
        public UIController() {}

        protected override void OnInit()
        {
            base.OnInit();
            rootPanel = new PanelRoot();
        }

        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            rootPanel.GameUpdate();
        }
    }

}