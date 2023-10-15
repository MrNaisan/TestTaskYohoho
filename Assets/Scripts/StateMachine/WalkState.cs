using ECS.States;
using UnityEngine;

namespace StateMachine
{
    public class WalkState : State
    {
        public WalkState(Animator _animator, string _trigger) : base(_animator, _trigger)
        {
            animator = _animator;
            trigger = _trigger;
        }
        
        public override void Enter()
        {
            base.Enter();
            animator.SetTrigger(trigger);
        }
    }
}