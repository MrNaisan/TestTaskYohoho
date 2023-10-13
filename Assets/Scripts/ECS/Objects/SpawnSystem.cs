using DefaultNamespace;
using Leopotam.Ecs;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using UnityEngine;

namespace ECS.Objects
{
    public class SpawnSystem : IEcsRunSystem
    {
        private readonly ObjectsPool pool = null;
        private readonly EcsFilter<SpawnDuration, SpawnComponent>.Exclude<SpawnBlockDuration> spawnFilter = null;
        
        public void Run()
        {
            foreach (var i in spawnFilter)
            {
                ref var entity = ref spawnFilter.GetEntity(i);
                ref var duration = ref spawnFilter.Get1(i).Duration;
                ref var spawnComponent = ref spawnFilter.Get2(i);

                ref var xSpace = ref spawnComponent.XSpace;
                ref var zSpace = ref spawnComponent.ZSpace;
                ref var yOffset = ref spawnComponent.YOffset;

                var pos = new Vector3(Random.Range(xSpace.x, xSpace.y), yOffset, Random.Range(zSpace.x, zSpace.y));

                pool.objectsPool.TryInstantiate(out _, pos, quaternion.identity);

                entity.Get<SpawnBlockDuration>().Timer = duration;
            }
        }
    }
}