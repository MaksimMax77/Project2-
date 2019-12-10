using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using FSM;
using UnityEngine;

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

