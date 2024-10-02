using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MiddleScene
{
    public class PanelRoom : IPanel
    {
        private CameraSystem system;
        private Collider2D collider;
        public PanelRoom(IPanel parent) : base(parent)
        {
            children.Add(new PanelSelectPlayer(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            system = GameMediator.Instance.GetSystem<CameraSystem>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (Input.GetMouseButtonDown(0))
            {
                collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, LayerMask.GetMask("Player"));
                if (collider)
                {
                    system.ChangeCamera(CameraType.SelectCamera);
                    system.SetSelectTarget(collider.transform.parent);
                    GetPanel<PanelSelectPlayer>().SetCollider(collider.transform.parent.gameObject);
                    EnterPanel<PanelSelectPlayer>();
                    gameObject.SetActive(false);
                }
            }
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            system.ChangeCamera(CameraType.StaticCamera);

        }
    }

}
