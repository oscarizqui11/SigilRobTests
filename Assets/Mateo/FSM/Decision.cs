using UnityEngine;

namespace FSM
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide (Controller controller);
    }
}
