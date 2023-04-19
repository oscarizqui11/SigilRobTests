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

        public int type;

        [SerializeField] private bool isFixedUpdate;

        virtual public void Start()
        {
            for (int i = 0; i < allStates.Length; i++)
                allStates[i].StartState(this);

            currentState = allStates[0];
        }

        virtual public void Update()
        {
            currentState.UpdateState(this);
        }

        virtual public void FixedUpdate()
        {
            if (!isFixedUpdate)
                return;

            currentState.FixedUpdateState(this);
        }

        public void Transition(State nextState)
        { 
            currentState = nextState;
        }
    }
}
