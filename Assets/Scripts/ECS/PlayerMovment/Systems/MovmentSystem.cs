using Leopotam.Ecs;

namespace ECS.PlayerMovment
{
    public class MovmentSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, DirectionComponent> movableFilter = null;
        
        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var movableComponent = ref movableFilter.Get1(i);
                ref var directionComponent = ref movableFilter.Get2(i);

                ref var controller = ref movableComponent.characterController;
                ref var speed = ref movableComponent.speed;
                var direction = directionComponent.direction;
                ref var transform = ref movableComponent.moveTransform;

                var rawDirection = (transform.right * direction.x) + (transform.forward * direction.y);
                controller.Move(rawDirection * speed);
            }
        }
    }
}