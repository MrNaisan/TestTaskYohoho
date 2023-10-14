using System.Collections.Generic;
using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Objects
{
    public class StackSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<StackableObjectsStack, StackableComponent> stackableFilter = null;

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
                
                for (int j = stack.Count - 1; j >= 0; j--)
                {
                    var el = stack.ElementAt(j);
                    
                    el.rotation = Quaternion.identity;

                    if (j == stack.Count - 1)
                        el.localPosition = Vector3.zero;
                    else
                    {
                        var prevEl = stack.ElementAt(j + 1);
                        var pos = new Vector3(prevEl.position.x, prevEl.position.y + el.localScale.y, prevEl.position.z);
                        el.position = Vector3.Lerp(el.position, pos, speed * Time.deltaTime);
                    }
                }
            }
        }
    }
}