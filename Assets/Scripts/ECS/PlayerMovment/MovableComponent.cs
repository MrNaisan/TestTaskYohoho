using System;
using UnityEngine;

namespace ECS.PlayerMovment
{
    [Serializable]
    public struct MovableComponent
    {
        public float speed;
        public CharacterController characterController;
        public Transform moveTransform;
    }
}