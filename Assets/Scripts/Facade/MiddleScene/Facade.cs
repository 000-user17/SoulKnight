using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        private PlayerController m_PlayerController;
        private InputController m_InputController;
        protected override void OnInit()
        {
            base.OnInit();
            m_InputController = new InputController();
            m_PlayerController = new PlayerController();

            GameMediator.Instance.RegisterController(m_InputController);
            GameMediator.Instance.RegisterController(m_PlayerController); // 注册控制器到中介者

        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            m_InputController.GameUpdate(); // 确保inputController的input先被实例化
            m_PlayerController.GameUpdate();
        }

    }


}