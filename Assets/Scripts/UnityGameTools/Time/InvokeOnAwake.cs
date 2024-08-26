using UnityEngine;
using UnityEngine.Events;

namespace UnityGameTools
{
    public class InvokeOnAwake : MonoBehaviour
    {
        public UnityEvent onAwake;

        void Awake() => onAwake?.Invoke();
    }
}