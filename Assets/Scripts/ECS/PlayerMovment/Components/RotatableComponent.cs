using System;
using UnityEngine;

namespace ECS.PlayerMovment
{
    [Serializable]
    public struct RotatableComponent
    {
        public float rotateSpeed;
        public Transform rotateTransform;
    }
}