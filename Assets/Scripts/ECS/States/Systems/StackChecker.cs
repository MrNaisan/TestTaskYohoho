using ECS.Objects;
using Leopotam.Ecs;

namespace ECS.States
{
    public class StackChecker : IEcsRunSystem
    {
        private readonly EcsFilter<StackableObjectsStack> stackFilter = null;

        private bool isHandsUp = false;
        
        public void Run()
        {
            foreach (var i in stackFilter)
            {
                ref var entity = ref stackFilter.GetEntity(i);
                ref var stack = ref stackFilter.Get1(i).stackedItems;

                if (stack.Count > 0 && !isHandsUp)
                {
                    isHandsUp = true;
                    entity.Get<HandsUpEvent>();
                }
                else if (stack.Count <= 0 && isHandsUp)
                {
                    isHandsUp = false;
                    entity.Get<HandsDownEvent>();
                }
            }
        }
    }
}