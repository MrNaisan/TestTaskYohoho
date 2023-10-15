using Pool;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Objects
{
    public class UnStackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnStackEvent, ModelComponent, DurationComponent>.Exclude<BlockDuration> unStackFilter = null;
        private readonly EcsFilter<StackableObjectsStack> listFilter = null;
        
        public void Run()
        {
            foreach (var i in unStackFilter)
            {
                ref var entity = ref unStackFilter.GetEntity(i);
                ref var stack = ref listFilter.Get1(i).stackedItems;
                ref var transform = ref unStackFilter.Get2(i).modelTransform;
                ref var duration = ref unStackFilter.Get3(i).Duration;
                
                entity.Del<UnStackEvent>();
                
                if(stack.Count <= 0) continue;
                
                stack.Pop().GetComponent<StackableObject>().ReturnToPool(transform);
                entity.Get<BlockDuration>().Timer = duration;
            }
        }
    }
}