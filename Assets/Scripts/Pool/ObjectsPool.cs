﻿using UnityEngine;

namespace Pool
{
    public class ObjectsPool : MonoBehaviour
    {
        [HideInInspector] public Pool<StackableObject> objectsPool;
        public int Count;
        public StackableObject Prefab;

        private void Start()
        {
            objectsPool = new Pool<StackableObject>(Prefab, Count, this.transform);
        }
    }
}