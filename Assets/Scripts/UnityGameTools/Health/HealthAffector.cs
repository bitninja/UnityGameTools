using UnityEngine;
using UnityEngine.Events;

namespace UnityGameTools
{
    public class HealthAffector : MonoBehaviour
    {
        public float amount = -1;

        [Tooltip("When set to true this object will be destroyed after affecting health.")]
        public bool destroyOnInteract = true;

        [Tooltip("Events to be handled before the destroy method is called.  Only relavent when Destroy On Iteract is set to true.")]
        public UnityEvent OnBeforeDestroy;

        private bool _isDestroyed;

        public void Affect(HasHealth health)
        {
            if (_isDestroyed) return;

            health.Adjust(amount);

            if (!destroyOnInteract) return;

            // For objects like bullets the following allows for destruction on contact.

            // This prevents double destroy events during same frame evaluation.
            // Typically caused by multiple colliders.
            _isDestroyed = true;
            OnBeforeDestroy?.Invoke();
            Destroy(gameObject, 0);
        }

        // Collisions and colliders can exist on different objects than then health affector, thus
        // utilize the appropriate collider and collision forwarders (i.e. Collision2DForwarder)
        // To relay this information to this affector.

        // PERFORMANCE NOTE! In the rare case that the forwarders are causing performance issues
        // it is recommended to creat a subclass of HealthAffector and add only the trigger
        // or collision methods required and invoke the appropriate handle method.

        public void HandleTrigger(Collider col) => Handle(col.gameObject);

        public void HandleTrigger2D(Collider2D col) => Handle(col.gameObject);

        public void HandleCollision(Collision col) => Handle(col.gameObject);

        public void HandleCollision2D(Collision2D col) => Handle(col.gameObject);

        private void Handle(GameObject other)
        {
            var health = other.GetComponent<HasHealth>();
            if (health == null) return;
            Affect(health);
        }
    }
}