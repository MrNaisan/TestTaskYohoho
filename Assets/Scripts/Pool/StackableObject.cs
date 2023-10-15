using System;
using UnityEngine;

namespace Pool
{
    public class StackableObject : PooledItem
    {
        [HideInInspector] public Collider collider;

        private void Start()
        {
            collider = GetComponent<Collider>();
        }

        private void OnDisable()
        {
            if (collider != null) 
                collider.enabled = true;
        }
    }
}