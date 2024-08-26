using UnityEngine;

namespace UnityGameTools
{
    public class EasingFollowMovement : MonoBehaviour
    {
        [Tooltip("Transform to follow.")]
        public Transform target;

        [Tooltip("Speed of the follow when at specified distance.")]
        public float speed;

        [Tooltip("Maximum distance from target (offset excluded).  This ensures that you have a max follow distance.")]
        public float maxDistance = float.MaxValue;

        [Tooltip("Distance from target to move at full speed.")]
        public float fullSpeedDistance = 1;

        [Tooltip("Tweak this to ensure no jitter and is close to target.")]
        public float zeroSpeedDistance = .01f;

        public Vector3 offset;

        void LateUpdate()
        {
            var diffVec = (target.position + offset) - transform.position;
            var direction = diffVec.normalized;

            var magnitude = diffVec.magnitude;
            if (zeroSpeedDistance >= magnitude)
            {
                return;
            }

            if (magnitude > maxDistance)
            {
                transform.position = (target.position + offset) - direction * maxDistance;
                return;
            }

            transform.position += direction * speed * Time.deltaTime * MathUtil.Sigmoid(fullSpeedDistance * (magnitude - 8) / 16);
        }

        // Provided for function referencing within the editor.  For example
        // when using a UnityEvent<Transform> field.
        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}