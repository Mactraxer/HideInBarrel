using Entities.Areas;
using System;
using System.Collections.Generic;

namespace Entities.Characters
{
    public class MainCharacterStateMachine
    {
        private Dictionary<Type, IMainCharacterState> _states;
        private IMainCharacterState _currentState;

        public Barrel Barrel;

        public MainCharacterStateMachine()
        {
            _states = new Dictionary<Type, IMainCharacterState>()
            {
                [typeof(SimpleCharacterState)] = new SimpleCharacterState(this),
                [typeof(WithBarrelCharacterState)] = new WithBarrelCharacterState(this)
            };
        }

        public void ChangeStateTo<TState>() where TState : IMainCharacterState
        {
            if (_states.TryGetValue(typeof(TState), out IMainCharacterState state))
            {
                _currentState?.Exit();
                _currentState = state;
                _currentState.Enter(this);
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