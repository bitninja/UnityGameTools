using UnityEngine;
using UnityEngine.Events;

namespace UnityGameTools
{
    public class FloatVarWatcher : MonoBehaviour
    {
        private float _lastKnownValue;
        public FloatVar watched;

        public UnityEvent<float> OnValueChanged;

        public UnityEvent<float> OnInitialized;

        void Start()
        {
            _lastKnownValue = watched.value;
            OnInitialized?.Invoke(watched.value);
        }

        void Update()
        {
            if (_lastKnownValue != watched.value)
            {
                _lastKnownValue = watched.value;
                OnValueChanged?.Invoke(watched.value);
            }
        }
    }
}