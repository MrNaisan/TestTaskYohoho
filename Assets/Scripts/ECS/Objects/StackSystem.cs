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
                    list[j].rotation = Quaternion.identity;

                    if (j == 0)
                        list[j].localPosition = Vector3.zero;
                    else
                    {
                        var pos = new Vector3(list[j - 1].position.x, list[j - 1].position.y + list[j].localScale.y, list[j - 1].position.z);
                        list[j].position = Vector3.Lerp(list[j].position, pos, speed * Time.deltaTime);
                    }
                }
            }
        }
    }
}