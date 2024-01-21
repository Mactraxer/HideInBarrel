using System;
using UnityEngine;

namespace Entities.Characters
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour
    {
        private readonly int RunParameter = Animator.StringToHash("Run");

        private Animator _animator;

        public void Init()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetRunAnimation()
        {
            _animator.SetBool(RunParameter, true);
        }

        public void StopRunAnimation()
        {
            _animator.SetBool(RunParameter, false);
        }

        internal void SetPuttingBarrelAnimation()
        {
            throw new NotImplementedException();
        }
    }
}