using Entities.Areas;
using Inputs;
using UnityEngine;

namespace Entities.Characters
{
    public class MainCharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private Transform _barrelSlot;

        private MainCharacterStateMachine _mainCharacterStateMachine;

        public void Init(IInputHandler inputHandler, ICoroutineRunner coroutineRunner)
        {
            _animator.Init();
            _mainCharacterStateMachine = new MainCharacterStateMachine(_movement, _animator, coroutineRunner, inputHandler, _barrelSlot);
            _mainCharacterStateMachine.ChangeStateTo<SimpleCharacterState>();
        }

        public void EnableMove()
        {
            _mainCharacterStateMachine.EnableMove();
        }

        public void DisableMove()
        {
            _mainCharacterStateMachine.DisableMove();
        }

        public void PutBarrel(Barrel barrel)
        {
            _mainCharacterStateMachine.SetBarrel(barrel);
            _mainCharacterStateMachine.ChangeStateTo<WithBarrelCharacterState>();
        }
    }
}