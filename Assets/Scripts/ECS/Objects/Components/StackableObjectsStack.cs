using System;
using System.Collections.Generic;
using UnityEngine;

namespace ECS.Objects
{
    [Serializable]
    public struct StackableObjectsStack
    {
        [HideInInspector] public Stack<Transform> stackedItems;
    }
}