using UnityEngine;

namespace FSM
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Innit(Controller controller);
        public abstract void Act(Controller controller);
    }
}
