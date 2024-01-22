using Entities.Areas;
using Inputs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Characters
{
    public class MainCharacterStateMachine
    {
        private readonly Dictionary<Type, IMainCharacterState> _states;
        private IMainCharacterState _currentState;

        public Barrel Barrel;

        public MainCharacterStateMachine(
            CharacterMovement movement,
            CharacterAnimator animator,
            ICoroutineRunner coroutineRunner,
            IInputHandler input,
            Transform barrelSlot
            )
        {
            _states = new Dictionary<Type, IMainCharacterState>()
            {
                [typeof(SimpleCharacterState)] = new SimpleCharacterState(this, movement, animator, coroutineRunner, input),
                [typeof(WithBarrelCharacterState)] = new WithBarrelCharacterState(this, movement, animator, coroutineRunner, input, barrelSlot)
            };
        }

        public void ChangeStateTo<TState>() where TState : IMainCharacterState
        {
            if (_states.TryGetValue(typeof(TState), out IMainCharacterState state))
            {
                _currentState?.Exit();
                _currentState = state;
                _currentState.Enter();
            }
            else
            {
                throw new InvalidOperationException("Failure change state to unknow state");
            }
        }

        public void DisableMove()
        {
            _currentState.SetActiveMovement(false);
        }

        public void EnableMove()
        {
            _currentState.SetActiveMovement(true);
        }

        public void SetBarrel(Barrel barrel)
        {
            Barrel = barrel;
        }
    }
}