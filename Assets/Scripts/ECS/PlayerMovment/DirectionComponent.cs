using System;
using UnityEngine;

namespace ECS.PlayerMovment
{
    [Serializable]
    public struct DirectionComponent
    {
        [HideInInspector] public Vector2 direction;
    }
}