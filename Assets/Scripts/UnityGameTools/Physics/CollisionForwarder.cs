using UnityEngine;
using UnityEngine.Events;

namespace UnityGameTools
{
    [RequireComponent(typeof(Collider))]
    public class CollisionForwarder : MonoBehaviour
    {
        public UnityEvent<Collision> OnEnter;
        public UnityEvent<Collision> OnExit;
        public UnityEvent<Collision> OnStay;

        void OnCollisionEnter(Collision collision) => OnEnter?.Invoke(collision);
        void OnCollisionExit(Collision collision) => OnExit?.Invoke(collision);
        void OnCollisionStay(Collision collision) => OnStay?.Invoke(collision);
    }
}