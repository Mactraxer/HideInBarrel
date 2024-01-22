using Inputs;
using System.Collections;
using UnityEngine;

namespace Entities.Characters
{
    public class SimpleCharacterState : IMainCharacterState
    {
        private MainCharacterStateMachine _mainCharacterStateMachine;
        private CharacterMovement _movement;
        private CharacterAnimator _animator;
        private ICoroutineRunner _coroutineRunner;
        private IInputHandler _inputHandler;

        private Coroutine _moveCoroutine;

        public SimpleCharacterState(
            MainCharacterStateMachine mainCharacterStateMachine,
            CharacterMovement movement,
            CharacterAnimator animator,
            ICoroutineRunner coroutineRunner,
            IInputHandler inputHandler
            )
        {
            _mainCharacterStateMachine = mainCharacterStateMachine;
            _movement = movement;
            _animator = animator;
            _coroutineRunner = coroutineRunner;
            _inputHandler = inputHandler;
        }

        public void Enter()
        {
            SetActiveMovement(true);
        }

        public void Exit()
        {
            SetActiveMovement(false);
            _animator.StopRunAnimation();
        }

        public void SetActiveMovement(bool active)
        {
            if (active)
            {
                _moveCoroutine = _coroutineRunner.Run(MoveCoroutine());
            }
            else
            {
                _coroutineRunner.Stop(_moveCoroutine);
            }
        }

        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                yield return null;
                var destination = new Vector3(_inputHandler.HorizontalInput, 0, _inputHandler.VerticalInput);
                destination.Normalize();
                _movement.MoveTo(destination);
                if (destination == Vector3.zero)
                {
                    _animator.StopRunAnimation();
                }
                else
                {
                    _animator.SetRunAnimation();
                }
            }
        }
    }
}