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

        protected override void OnEnter()
        {
            base.OnEnter();
            GameMediator.Instance.GetSystem<CameraSystem>().ChangeCamera(CameraType.FollowCamera);
            GameMediator.Instance.GetSystem<CameraSystem>().
                SetFollowTarget(GameMediator.Instance.GetController<PlayerController>().MainPlayer.transform);
        }
    }
}
