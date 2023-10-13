using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Objects
{
    public class StackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StackableObjectsList, StackableComponent> stackableFilter = null;
        
        public void Run()
        {
            foreach (var i in stackableFilter)
            {
                ref var stackableList = ref stackableFilter.Get1(i);
                ref var stackableComponent = ref stackableFilter.Get2(i);

                ref var list = ref stackableList.stackedItems;
                ref var speed = ref stackableComponent.speed;

                for (int j = 0; j < list.Count; j++)
                {
                    if(i == 0) continue;

                    list[i].position = Vector3.Lerp(list[i].position, list[i - 1].position, speed * Time.deltaTime);
                }
            }
        }
    }
}