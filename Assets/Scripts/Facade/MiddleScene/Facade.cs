using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        private PlayerController m_PlayerController;
        protected override void OnInit()
        {
            base.OnInit();
            m_PlayerController = new PlayerController();

            GameMediator.Instance.RegisterController(m_PlayerController);

        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            m_PlayerController.GameUpdate();
        }

    }


}