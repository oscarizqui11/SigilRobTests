using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public class State : ScriptableObject
    {
        public Action[] updateActions;
        public Action[] fixedUpdateActions;
        public Transition[] transitions;

        public void UpdateState(Controller controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        public void FixedUpdateState(Controller controller)
        {
            DoActionsFixedUpdate(controller);
        }

        private void DoActions(Controller controller) 
        { 
            for(int i = 0; i < updateActions.Length; i++)
                updateActions[i].Act(controller);
        }

        private void DoActionsFixedUpdate(Controller controller)
        {
            for (int i = 0; i < fixedUpdateActions.Length; i++)
                fixedUpdateActions[i].Act(controller);
        }

        private void CheckTransitions(Controller controller)
        {
            for(int i = 0; i < transitions.Length; i++)
            {
                bool decision = transitions[i].decision.Decide(controller);

                if(decision)
                {
                    controller.Transition(transitions[i].trueState);
                    return;
                }
            }
        }
    }
}
