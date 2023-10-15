using ECS.States;
using UnityEngine;

namespace StateMachine
{
    public class State
    {
        public Animator animator;
        public string trigger;
 
        public State(Animator _animator, string _trigger)
        {
            animator = _animator;
            trigger = _trigger;
        }
 
        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}