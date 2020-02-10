using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public interface IState
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();
        bool CanTransit(out IState targetState);
    }

    public abstract class State : IState
    {
	   
        private List<Transition> transitions = new List<Transition>();

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();

        public void Add(Transition transition)
        {
            transitions.Add(transition);
        }

        public bool CanTransit(out IState targetState)
        {
            for (var i = 0; i < transitions.Count; i++)
            {
                var transition = transitions[i];
                if (transition.condition())
                {
                    targetState = transition.targetState;
                    return true;
                }
            }

            targetState = null;
            return false;
        }
    }
}
