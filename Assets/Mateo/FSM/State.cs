using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public class State : ScriptableObject
    {
        public Action[] updateActions;
        public Action[] fixedUpdateActions;
        public Transition[] transitions;

        public void StartState(Controller controller)
        {
            StartAction(controller);
        }

        public void UpdateState(Controller controller)
        {
            CheckTransitions(controller);
            DoActions(controller);
        }

        public void FixedUpdateState(Controller controller)
        {
            DoActionsFixedUpdate(controller);
        }

        private void StartAction(Controller controller)
        {
            for (int i = 0; i < updateActions.Length; i++)
                updateActions[i].Innit(controller);

            for (int i = 0; i < fixedUpdateActions.Length; i++)
                fixedUpdateActions[i].Innit(controller);
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
