using UnityEngine;

namespace UnityGameTools
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public float ttl = 0f;

        public bool awaitManualStart = false;

        void Start()
        {
            if (awaitManualStart)
            {
                return;
            }

            GameObject.Destroy(this.gameObject, ttl);
        }

        public void StartDestroyTTL()
        {
            GameObject.Destroy(this.gameObject, ttl);
        }
    }
}