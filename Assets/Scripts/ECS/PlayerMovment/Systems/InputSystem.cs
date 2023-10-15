using ECS.States;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.PlayerMovment
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly Joystick joystick = null;

        private readonly EcsFilter<DirectionComponent> directionFilter = null;

        private bool isWalkAnim = false;
        
        public void Run()
        {
            foreach (var i in directionFilter)
            {
                ref var entity = ref directionFilter.GetEntity(i);
                ref var direction = ref directionFilter.Get1(i).direction;
                
                direction = joystick.Direction;

                if (direction != Vector2.zero && !isWalkAnim)
                {
                    isWalkAnim = true;
                    entity.Get<WalkEvent>();
                }
                else if(direction == Vector2.zero && isWalkAnim)
                {
                    isWalkAnim = false;
                    entity.Get<IdleEvent>();
                }
            }
        }
    }
}