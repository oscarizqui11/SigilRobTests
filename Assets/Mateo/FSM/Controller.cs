using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Controller : MonoBehaviour
    {
        public State currentState;

        public State[] allStates;

        public bool ActiveObject;

        virtual public void Start()
        { 
            ActiveObject = true;

            for (int i = 0; i < allStates.Length; i++)
                allStates[i].StartState(this);
        }

        virtual public void Update()
        {
            if (!ActiveObject)
                return;

            currentState.UpdateState(this);
        }

        public void Transition(State nextState)
        { 
            currentState = nextState;
        }
    }
}
