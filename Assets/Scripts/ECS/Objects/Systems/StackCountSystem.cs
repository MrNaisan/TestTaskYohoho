using Leopotam.Ecs;

namespace ECS.Objects
{
    public class StackCountSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StackableObjectsStack> stackFilter = null;
        private readonly EcsFilter<UITextComponent> textFilter = null;
        
        private int count;
        
        public void Run()
        {
            foreach (var i in stackFilter)
            {
                ref var stack = ref stackFilter.Get1(i).stackedItems;
                count = stack.Count;
            }

            foreach (var i in textFilter)
            {
                ref var text = ref textFilter.Get1(i).Text;

                text.text = $"{count}";
            }
        }
    }
}