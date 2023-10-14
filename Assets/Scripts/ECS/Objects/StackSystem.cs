using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Objects
{
    public class StackSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<StackableObjectsStack, StackableComponent> stackableFilter = null;

        private Transform prevObj;

        public void Init()
        {
            foreach (var i in stackableFilter)
            {
                ref var stack = ref stackableFilter.Get1(i).stackedItems;
                stack = new Stack<Transform>();
            }
        }
        
        public void Run()
        {
            foreach (var i in stackableFilter)
            {
                ref var stackComponent = ref stackableFilter.Get1(i);
                ref var stackableComponent = ref stackableFilter.Get2(i);

                ref var stack = ref stackComponent.stackedItems;
                ref var speed = ref stackableComponent.speed;
                
                foreach (var obj in stack)
                {
                    obj.rotation = Quaternion.identity;

                    if (obj == stack.Peek())
                        obj.localPosition = Vector3.zero;
                    else
                    {
                        var pos = new Vector3(prevObj.position.x, prevObj.position.y + obj.localScale.y, prevObj.position.z);
                        obj.position = Vector3.Lerp(obj.position, pos, speed * Time.deltaTime);
                    }

                    prevObj = obj;
                }
            }
        }
    }
}