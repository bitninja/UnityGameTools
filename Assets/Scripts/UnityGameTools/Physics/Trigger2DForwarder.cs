using UnityEngine;
using UnityEngine.Events;


namespace UnityGameTools
{
    [RequireComponent(typeof(Collider2D))]
    public class Trigger2DForwarder : MonoBehaviour
    {
        public UnityEvent<Collider2D> OnEnter;
        public UnityEvent<Collider2D> OnExit;
        public UnityEvent<Collider2D> OnStay;

        void OnTriggerEnter2D(Collider2D col) => OnEnter?.Invoke(col);
        void OnTriggerExit2D(Collider2D col) => OnExit?.Invoke(col);
        void OnTriggerStay2D(Collider2D col) => OnStay?.Invoke(col);
    }
}