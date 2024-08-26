using UnityEngine;
using UnityEngine.Events;

namespace UnityGameTools
{
    [RequireComponent(typeof(Collider2D))]
    public class Collision2DForwarder : MonoBehaviour
    {
        public UnityEvent<Collision2D> OnEnter;
        public UnityEvent<Collision2D> OnExit;
        public UnityEvent<Collision2D> OnStay;

        void OnCollisionEnter2D(Collision2D collision) => OnEnter?.Invoke(collision);
        void OnCollisionExit2D(Collision2D collision) => OnExit?.Invoke(collision);
        void OnCollisionStay2D(Collision2D collision) => OnStay?.Invoke(collision);
    }
}