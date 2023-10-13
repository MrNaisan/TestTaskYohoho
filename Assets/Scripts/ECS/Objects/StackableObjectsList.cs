using System;
using System.Collections.Generic;
using UnityEngine;

namespace ECS.Objects
{
    [Serializable]
    public struct StackableObjectsList
    {
        [HideInInspector] public List<Transform> stackedItems;
    }
}