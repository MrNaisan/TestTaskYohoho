using Leopotam.Ecs;
using UnityEngine;

namespace ECS.PlayerMovment
{
    public class RotateSystem : IEcsRunSystem
    {
        private readonly EcsFilter< DirectionComponent, RotatableComponent> rotatableFileter = null;
        
        public void Run()
        {
            foreach (var i in rotatableFileter)
            {
                ref var directionComponent = ref rotatableFileter.Get1(i);
                ref var rotatableComponent = ref rotatableFileter.Get2(i);

                ref var direction = ref directionComponent.direction;
                ref var transform = ref rotatableComponent.rotateTransform;
                ref var speed = ref rotatableComponent.rotateSpeed;
                
                var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            }
        }
    }
}