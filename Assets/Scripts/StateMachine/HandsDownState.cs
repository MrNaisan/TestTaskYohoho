using UnityEngine;

namespace StateMachine
{
    public class HandsDownState : State
    {
        public HandsDownState(Animator _animator, string _trigger) : base(_animator, _trigger)
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