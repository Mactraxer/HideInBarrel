using UnityEngine;

namespace Entities.Characters
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _rotationSpeed;

        public void MoveTo(Vector3 destination)
        {
            _target.Translate(destination * Time.fixedDeltaTime * _runSpeed, Space.World);

            if (destination != Vector3.zero)
            {
                var rotation = Quaternion.LookRotation(destination, Vector3.up);
                _target.rotation = Quaternion.RotateTowards(_target.rotation, rotation, _rotationSpeed * Time.fixedDeltaTime);  
            }
        }
    }
}