using UnityEngine;
using UnityEngine.Events;


namespace UnityGameTools
{
    [RequireComponent(typeof(Collider))]
    public class TriggerForwarder : MonoBehaviour
    {
        public UnityEvent<Collider> OnEnter;
        public UnityEvent<Collider> OnExit;
        public UnityEvent<Collider> OnStay;

        void OnTriggerEnter(Collider col) => OnEnter?.Invoke(col);
        void OnTriggerExit(Collider col) => OnExit?.Invoke(col);
        void OnTriggerStay(Collider col) => OnStay?.Invoke(col);
    }
}