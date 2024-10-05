using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        // 决定控制器时许，那个先执行，哪个后执行
        private ItemController m_ItemController;
        private PlayerController m_PlayerController;
        private InputController m_InputController;
        private CameraSystem m_CameraSystem;
        private UIController m_UIController;
        private EnemyController m_EnemyController;
        protected override void OnInit()
        {
            base.OnInit();
            m_ItemController = new ItemController();
            m_InputController = new InputController();
            m_CameraSystem = new CameraSystem();
            m_PlayerController = new PlayerController();
            m_EnemyController = new EnemyController();
            m_UIController = new UIController();

            GameMediator.Instance.RegisterController(m_ItemController);
            GameMediator.Instance.RegisterController(m_InputController);
            GameMediator.Instance.RegisterController(m_PlayerController); // 注册控制器到中介者
            GameMediator.Instance.RegisterController(m_EnemyController);
            GameMediator.Instance.RegisterController(m_UIController);
            GameMediator.Instance.RegisterSystem(m_CameraSystem);
            EventCenter.Instance.RegisterObserver(EventType.OnSelectPlayerFinish, () =>
            {
                m_PlayerController.TurnOnController();
            });
            m_EnemyController.TurnOnController();
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            m_ItemController.GameUpdate();
            m_InputController.GameUpdate(); // 确保inputController的input先被实例化
            m_PlayerController.GameUpdate();
            m_EnemyController?.GameUpdate();
            m_UIController.GameUpdate();

        }

    }


}