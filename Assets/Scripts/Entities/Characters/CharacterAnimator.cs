using UnityEngine;

namespace Entities.Characters
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour
    {
        private readonly int RunParameter = Animator.StringToHash("Run");
        private readonly int RunWithBarrelParameter = Animator.StringToHash("RunWithBarrel");
        private readonly int PuttingBarrelParameter = Animator.StringToHash("PutBarrel");

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

        public void SetPuttingBarrelAnimation()
        {
            _animator.SetTrigger(PuttingBarrelParameter);
        }

        public void SetRunWithBarrelAnimation()
        {
            _animator.SetBool(RunWithBarrelParameter, true);
        }

        public void StopRunWithBarrelAnimation()
        {
            _animator.SetBool(RunWithBarrelParameter, false);
        }
    }
}