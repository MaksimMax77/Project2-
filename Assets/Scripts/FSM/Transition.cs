using System;

namespace FSM
{
    public struct Transition
    {
        public IState targetState;
        public Func<bool> condition;

        public Transition(IState targetState, Func<bool> condition)
        {
            this.targetState = targetState;
            this.condition = condition;
        }
    }
}

