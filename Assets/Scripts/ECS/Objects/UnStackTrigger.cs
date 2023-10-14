using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ECS.Objects
{
    public class UnStackTrigger : MonoBehaviour
    {
        private EntityReference entityReference;

        private void Start()
        {
            entityReference = GetComponent<EntityReference>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<CharacterController>(out _))
            {
                entityReference.Entity.Get<UnStackEvent>();
            }
        }
    }
}