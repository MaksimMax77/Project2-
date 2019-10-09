using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class StateMachine
    {
        private IState currentState;

        public StateMachine(IState beginState)
        {
            currentState = beginState;
             currentState.OnEnter();
        }


        public void OnUpdate()
        {
            if (currentState.CanTransit(out var targetState))
            {
                currentState.OnExit();
                targetState.OnEnter();

                currentState = targetState;
            }
            else
            {
                currentState.OnUpdate();
            }
        }
    }
}
