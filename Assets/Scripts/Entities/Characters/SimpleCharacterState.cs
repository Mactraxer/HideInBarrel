using Inputs;
using System.Collections;
using UnityEngine;

namespace Entities.Characters
{
    public class SimpleCharacterState : IMainCharacterState
    {
        private CharacterMovement _movement;
        private CharacterAnimator _animator;
        private MainCharacterStateMachine _mainCharacterStateMachine;
        private Coroutine _moveCoroutine;
        private ICoroutineRunner _coroutineRunner;
        private IInputHandler _inputHandler;

        public SimpleCharacterState(MainCharacterStateMachine mainCharacterStateMachine)
        {
            _mainCharacterStateMachine = mainCharacterStateMachine;
        }

        public void Enter(MainCharacterStateMachine contex)
        {
            SetActiveMovement(true);
        }

        public void Exit()
        {
            SetActiveMovement(false);
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