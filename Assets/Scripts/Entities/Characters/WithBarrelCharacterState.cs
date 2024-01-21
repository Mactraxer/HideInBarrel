using Entities.Areas;
using UnityEngine;

namespace Entities.Characters
{
    public class WithBarrelCharacterState : IMainCharacterState
    {
        private CharacterMovement _movement;
        private CharacterAnimator _animator;
        private MainCharacterStateMachine _mainCharacterStateMachine;
        private Barrel _barrel;
        private Transform _barrelSlot;

        public WithBarrelCharacterState(MainCharacterStateMachine mainCharacterStateMachine)
        {
            _mainCharacterStateMachine = mainCharacterStateMachine;
        }

        public void Enter(MainCharacterStateMachine contex)
        {
            PutBarrel(contex.Barrel);
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void SetActiveMovement(bool active)
        {
            throw new System.NotImplementedException();
        }

        private void PutBarrel(Barrel barrel)
        {
            _barrel = barrel;
            _barrel.transform.parent = _barrelSlot;
            _barrel.transform.position = _barrelSlot.transform.position;
            _animator.SetPuttingBarrelAnimation();
        }
    }
}