using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Objects
{
    public class SpawnBlockSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnBlockDuration> blockFilter = null;
        
        public void Run()
        {
            foreach (var i in blockFilter)
            {
                ref var entity = ref blockFilter.GetEntity(i);
                ref var time = ref blockFilter.Get1(i).Timer;

                time -= Time.deltaTime;
                if(time <= 0)
                    entity.Del<SpawnBlockDuration>();
            }
        }
    }
}