using Leopotam.Ecs;

namespace ECS.PlayerMovment
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly Joystick joystick = null;

        private readonly EcsFilter<DirectionComponent> directionFilter = null;
        
        public void Run()
        {
            foreach (var i in directionFilter)
            {
                ref var direction = ref directionFilter.Get1(i).direction;
                direction = joystick.Direction;
            }
        }
    }
}