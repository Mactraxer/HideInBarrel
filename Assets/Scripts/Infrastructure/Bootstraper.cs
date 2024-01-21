using Cinemachine;
using Entities.Characters;
using Factories;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private InputJoystick _input;
        [SerializeField] private MonoBehaviourCoroutineRunner _coroutineRunner;
        [SerializeField] private MainCharacterController _mainCharacterPrefab;
        [SerializeField] private CinemachineVirtualCamera _playerVirtualCamera;

        private BootstrapStateMachine _stateMachine;
        private ServiceLocator _serviceLocator;

        private void Start()
        {
            InitServiceLocator();
            InitStateMachine();

            _stateMachine.Start();
        }

        private void InitServiceLocator()
        {
            var mainCharacterFactory = new MainCharacterFactory(_mainCharacterPrefab, _input, _coroutineRunner);
            var enemyCharacterFactory = new EnemyCharacterFactory();
            _serviceLocator = new ServiceLocator(_input, enemyCharacterFactory, mainCharacterFactory);
        }

        private void InitStateMachine()
        {
            var bootstrapState = new BootstrapState();
            var loadingState = new LoadingState();
            var gameState = new GameState(_serviceLocator, _playerVirtualCamera);
            var winState = new WinState();
            var loseState = new LoseState();

            _stateMachine = new BootstrapStateMachine(bootstrapState, loadingState, gameState, winState, loseState);
        }
    }
}