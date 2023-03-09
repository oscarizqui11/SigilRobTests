using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Controller : MonoBehaviour
    {
        public State currentState;

        public bool ActiveObject;

        virtual public void Start()
        { 
            ActiveObject = true;
            currentState.StartState(this);
        }

        virtual public void Update()
        {
            if (!ActiveObject)
                return;

            currentState.UpdateState(this);
        }

        public void Transition(State nextState)
        { currentState = nextState; }
    }
}
