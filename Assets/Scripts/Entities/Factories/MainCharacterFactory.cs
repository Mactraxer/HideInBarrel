using Entities.Characters;
using Inputs;
using UnityEngine;

namespace Factories
{
    public class MainCharacterFactory
    {
        private MainCharacterController _prefab;
        private IInputHandler _input;
        private ICoroutineRunner _coroutineRunner;

        public MainCharacterFactory(MainCharacterController prefab, IInputHandler input, ICoroutineRunner coroutineRunner)
        {
            _prefab = prefab;
            _input = input;
            _coroutineRunner = coroutineRunner;
        }

        public MainCharacterController GetCharacter()
        {
            var character = Object.Instantiate(_prefab);
            character.Init(_input, _coroutineRunner);
            return character;
        }
    }
}