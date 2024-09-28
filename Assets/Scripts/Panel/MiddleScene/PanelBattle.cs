using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiddleScene
{
    public class PanelBattle : IPanel
    {
    public PanelBattle(IPanel parent) : base(parent)
    {

    }

        protected override void OnInit()
        {
            base.OnInit();
        }
    }
}
