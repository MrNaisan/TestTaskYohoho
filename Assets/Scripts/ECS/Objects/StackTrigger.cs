using System;
using DefaultNamespace;
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
            if (other.TryGetComponent<StackableObject>(out _))
            {
                ref var list = ref entityReference.Entity.Get<StackableObjectsList>().stackedItems;
                if(list.Count <= 0)
                    other.transform.parent = this.transform;
                list.Add(other.transform);
            }
        }
    }
}