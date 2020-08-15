using UnityEngine.Events;

// Class has to be in this namespace due to compatibility
namespace CustomSaber
{
    [UnityEngine.AddComponentMenu("Custom Sabers/Combo Reached Event")]
    public class ComboReachedEvent : EventFilterBehaviour
    {
        public int ComboTarget = 50;
        public bool InvokeEveryNCombo = false;
        public UnityEvent NthComboReached;
        public UnityEvent ComboDropped;

#if PLUGIN
        private void OnEnable() => EventManager.OnComboChanged.AddListener(OnComboReached);
        private void OnDisable() => EventManager.OnComboChanged.RemoveListener(OnComboReached);

        private void OnComboReached(int combo)
        {
            if (combo == ComboTarget)
            {
                NthComboReached.Invoke();
            }else if(combo == 0)
            {
                ComboDropped?.Invoke();
            }else if(InvokeEveryNCombo == true && combo % ComboTarget == 0)
            {
                NthComboReached.Invoke();
            }
        }
#endif
    }
}
