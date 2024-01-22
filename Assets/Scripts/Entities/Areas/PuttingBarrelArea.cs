using Entities.Characters;
using UnityEngine;

namespace Entities.Areas
{
    [RequireComponent(typeof(Collider))]
    public class PuttingBarrelArea : MonoBehaviour
    {
        [SerializeField] private Barrel _barrel;

        private Collider _collider;

        private void Start ()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out MainCharacterController characterController))
                return;

            characterController.PutBarrel(_barrel);
            SetActive(false);
        }

        private void SetActive(bool active)
        {
            _collider.enabled = active;
        }
    }
}