using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class Controller : MonoBehaviour
    {
        [Header("FSM")]
        public State currentState;
        public State[] allStates;

        public bool ActiveObject;
        public bool isFixedUpdate;

        virtual public void Start()
        { 
            ActiveObject = true;

            for (int i = 0; i < allStates.Length; i++)
                allStates[i].StartState(this);

            currentState = allStates[0];
        }

        virtual public void Update()
        {
            if (!ActiveObject)
                return;

            currentState.UpdateState(this);
        }

        virtual public void FixedUpdate()
        {
            if (!ActiveObject || !isFixedUpdate)
                return;

            currentState.FixedUpdateState(this);
        }

        public void Transition(State nextState)
        { 
            currentState = nextState;
        }
    }
}
