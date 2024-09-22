using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 负责控制各个控制器的时序，以及控制器的开关
外观模式通过为子系统中的一组接口提供一个统一的接口，从而简化客户端对这些子系统的调用。
 简化客户端调用*/
namespace MainMenuScene
{
    public class Facade : AbstractFacade
    {
        private UIController m_UIController;
        protected override void OnInit()
        {
            base.OnInit();
            m_UIController = new UIController();
            // 在中介类注册UI控制器
            GameMediator.Instance.RegisterController(m_UIController);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            m_UIController.GameUpdate();
        }
    }
}
