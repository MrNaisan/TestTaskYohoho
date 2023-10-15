using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Objects
{
    public class BlockSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockDuration> blockFilter = null;
        
        public void Run()
        {
            foreach (var i in blockFilter)
            {
                ref var entity = ref blockFilter.GetEntity(i);
                ref var time = ref blockFilter.Get1(i).Timer;

                time -= Time.deltaTime;
                if(time <= 0)
                    entity.Del<BlockDuration>();
            }
        }
    }
}