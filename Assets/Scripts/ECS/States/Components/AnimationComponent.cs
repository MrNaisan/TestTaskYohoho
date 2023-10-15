using System;
using UnityEngine;

namespace ECS.States
{
    [Serializable]
    public struct AnimationComponent
    {
        public Animator animator;
        public string idleTrigger;
        public string walkTrigger;
        public string handsUpTrigger;
        public string handsDownTrigger;
    }
}