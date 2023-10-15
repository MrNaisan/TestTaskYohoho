using ECS.Objects;
using Leopotam.Ecs;
using StateMachine;
using UnityEngine;

namespace ECS.States
{
    public class StateSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<WalkEvent> walkFilter = null;
        private readonly EcsFilter<IdleEvent> idleFilter = null;
        private readonly EcsFilter<HandsUpEvent> handsUpFilter = null;
        private readonly EcsFilter<HandsDownEvent> handsDownFilter = null;
        private readonly EcsFilter<AnimationComponent> initFilter = null;

        private StateMachine.StateMachine stateMachine;
        private IdleState idle;
        private WalkState walk;
        private HandsUpState handsUp;
        private HandsDownState handsDown;

        public void Init()
        {
            stateMachine = new StateMachine.StateMachine();
            
            foreach (var i in initFilter)
            {
                ref var animComponent = ref initFilter.Get1(i);

                ref var animator = ref animComponent.animator;
                ref var idleTrigger = ref animComponent.idleTrigger;
                ref var walkTrigger = ref animComponent.walkTrigger;
                ref var handsUpTrigger = ref animComponent.handsUpTrigger;
                ref var handsDownTrigger = ref animComponent.handsDownTrigger;
                
                idle = new IdleState(animator, idleTrigger);
                walk = new WalkState(animator, walkTrigger);
                handsUp = new HandsUpState(animator, handsUpTrigger);
                handsDown = new HandsDownState(animator, handsDownTrigger);
            }
            
            stateMachine.Initialize(idle);
        }
        
        public void Run()
        {
            
            foreach (var i in idleFilter)
            {
                stateMachine.ChangeState(idle);
            }

            foreach (var i in walkFilter)
            {
                stateMachine.ChangeState(walk);
            }

            foreach (var i in handsUpFilter)
            {
                stateMachine.ChangeState(handsUp);
            }

            foreach (var i in handsDownFilter)
            {
                stateMachine.ChangeState(handsDown);
            }
        }
    }
}