using Entities.Areas;
using Inputs;
using System.Collections;
using UnityEngine;

namespace Entities.Characters
{
    public class WithBarrelCharacterState : IMainCharacterState
    {
        private MainCharacterStateMachine _mainCharacterStateMachine;
        private CharacterMovement _movement;
        private CharacterAnimator _animator;
        private ICoroutineRunner _coroutineRunner;
        private IInputHandler _inputHandler;

        private Transform _barrelSlot;
        private Coroutine _moveCoroutine;
        private Barrel _barrel;

        public WithBarrelCharacterState(
            MainCharacterStateMachine mainCharacterStateMachine,
            CharacterMovement movement,
            CharacterAnimator animator,
            ICoroutineRunner coroutineRunner,
            IInputHandler inputHandler,
            Transform barrelSlot
            )
        {
            _mainCharacterStateMachine = mainCharacterStateMachine;
            _movement = movement;
            _animator = animator;
            _coroutineRunner = coroutineRunner;
            _inputHandler = inputHandler;
            _barrelSlot = barrelSlot;
        }

        public void Enter()
        {
            PutBarrel(_mainCharacterStateMachine.Barrel);
            SetActiveMovement(true);
        }

        public void Exit()
        {
            
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

        private void PutBarrel(Barrel barrel)
        {
            _barrel = barrel;
            _barrel.transform.parent = _barrelSlot;
            _barrel.transform.position = _barrelSlot.transform.position;
            _animator.SetPuttingBarrelAnimation();
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
                    _animator.StopRunWithBarrelAnimation();
                }
                else
                {
                    _animator.SetRunWithBarrelAnimation();
                }
            }
        }
    }
}