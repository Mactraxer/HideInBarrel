using Cinemachine;
using Entities.Characters;
using UnityEngine;

namespace Infrastructure
{
    public class GameState : IState
    {
        private ServiceLocator _serviceLocator;
        private CinemachineVirtualCamera _virtualCamera;

        private MainCharacterController _character;

        public GameState(ServiceLocator serviceLocator, CinemachineVirtualCamera virtualCamera)
        {
            _serviceLocator = serviceLocator;
            _virtualCamera = virtualCamera;
        }

        public void Enter()
        {
            _character = _serviceLocator._mainCharacterSpawner.GetCharacter();

            SetupCamera(_character.transform);
        }

        private void SetupCamera(Transform target)
        {
            _virtualCamera.m_Follow = target;
            _virtualCamera.m_LookAt = target;
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}