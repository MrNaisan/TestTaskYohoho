using System;
using UnityEngine;

namespace ECS.Objects
{
    [Serializable]
    public struct SpawnComponent
    {
        public Vector2 XSpace;
        public Vector2 ZSpace;
        public float YOffset;
    }
}