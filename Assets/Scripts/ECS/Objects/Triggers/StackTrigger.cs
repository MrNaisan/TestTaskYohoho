using System;
using Pool;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Objects
{
    public class StackTrigger : MonoBehaviour
    {
        private EntityReference entityReference;

        private void Start()
        {
            entityReference = GetComponent<EntityReference>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<StackableObject>(out StackableObject obj))
            {
                obj.collider.enabled = false;
                ref var list = ref entityReference.Entity.Get<StackableObjectsStack>().stackedItems;
                if(list.Count <= 0)
                    other.transform.parent = this.transform;
                list.Push(other.transform);
            }
        }
    }
}