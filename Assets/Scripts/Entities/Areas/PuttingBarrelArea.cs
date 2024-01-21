using Entities.Characters;
using UnityEngine;

namespace Entities.Areas
{
    [RequireComponent(typeof(Collider))]
    public class PuttingBarrelArea : MonoBehaviour
    {
        [SerializeField] private Barrel _barrel;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out MainCharacterController characterController))
                return;

            characterController.PutBarrel(_barrel);
        }
    }
}