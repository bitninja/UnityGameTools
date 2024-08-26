using UnityEngine;
using UnityEngine.Events;

namespace UnityGameTools
{
    public class HasHealth : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float health = 100;
        public bool destroyOnHealthDepleted = false;
        public bool isInvulnerable;

        #region Health Events

        public UnityEvent OnHealthDepleted;
        public UnityEvent OnHealthIncreased;
        public UnityEvent OnHealthDecreased;
        public UnityEvent OnHitInvulnerable;

        #endregion

        public void Adjust(float amount)
        {
            if (health <= 0) return;
            if (amount == 0) return;

            var proposedNewHealth = health + amount;

            // If in an invulnerable stage ignore damage amounts        
            if (isInvulnerable && amount < 0)
            {
                OnHitInvulnerable?.Invoke();
                return;
            }

            health = Mathf.Clamp(proposedNewHealth, 0, maxHealth);

            // Notify when the health has been dropped to zero or below.
            if (proposedNewHealth <= 0)
            {
                OnHealthDepleted?.Invoke();
                if (destroyOnHealthDepleted) Destroy(gameObject, 0f);

                return;
            }

            if (amount < 0)
            {
                OnHealthDecreased?.Invoke();
            }
            else
            {
                OnHealthIncreased?.Invoke();
            }
        }
    }
}