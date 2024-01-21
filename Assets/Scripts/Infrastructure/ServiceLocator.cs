using Factories;
using Inputs;

namespace Infrastructure
{
    public class ServiceLocator
    {
        private IInputHandler _inputHandler;
        private EnemyCharacterFactory _enemyCharacterSpawner;
        public MainCharacterFactory _mainCharacterSpawner;

        public ServiceLocator(IInputHandler inputHandler, EnemyCharacterFactory enemyCharacterSpawner, MainCharacterFactory mainCharacterSpawner)
        {
            _inputHandler = inputHandler;
            _enemyCharacterSpawner = enemyCharacterSpawner;
            _mainCharacterSpawner = mainCharacterSpawner;
        }
    }
}