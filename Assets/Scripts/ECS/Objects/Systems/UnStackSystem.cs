using Pool;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Objects
{
    public class UnStackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnStackEvent, ModelComponent, DurationComponent, GameTextComponent>.Exclude<BlockDuration> unStackFilter = null;
        private readonly EcsFilter<StackableObjectsStack> listFilter = null;
        private readonly EcsFilter<UnStackEvent, BlockDuration> blockFilter = null;

        private int count;
        
        public void Run()
        {
            foreach (var i in blockFilter)
            {
                ref var entity = ref blockFilter.GetEntity(i);
                
                entity.Del<UnStackEvent>();
            }
            
            foreach (var i in unStackFilter)
            {
                ref var entity = ref unStackFilter.GetEntity(i);
                ref var stack = ref listFilter.Get1(i).stackedItems;
                ref var transform = ref unStackFilter.Get2(i).modelTransform;
                ref var duration = ref unStackFilter.Get3(i).Duration;
                ref var text = ref unStackFilter.Get4(i).Text;
                
                entity.Del<UnStackEvent>();
                
                if(stack.Count <= 0) continue;

                count++;
                text.text = $"{count}";
                    
                stack.Pop().GetComponent<StackableObject>().ReturnToPool(transform);
                entity.Get<BlockDuration>().Timer = duration;
            }
        }
    }
}