using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class PanelRoot : IPanel
    {
        public PanelRoot() : base(null) {
            children.Add(new PanelRoom(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            Resume();
            EventCenter.Instance.RegisterObserver(EventType.OnSelectPlayerFinish, () =>
            {
                gameObject.SetActive(false);
            });
        }
        protected override void OnEnter()
        {
            base.OnEnter();
            EnterPanel<PanelRoom>();
        }

    }
}
