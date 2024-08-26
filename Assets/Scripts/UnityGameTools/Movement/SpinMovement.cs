using System.Collections;
using UnityEngine;

namespace UnityGameTools
{
    public class SpinMovement : MonoBehaviour
    {
        private static readonly string RunMovementMethod = "RunMovement";

        [Tooltip("The rotation speed for each axis.")]
        public Vector3 axisRotationSpeeds;

        public bool startOnAwake = true;

        private float _direction = 1f;

        void Awake()
        {
            if (!startOnAwake)
            {
                return;
            }

            StartMovement();
        }

        public void SetAxisRotationSpeeds(Vector3 speed)
        {
            axisRotationSpeeds = speed;
        }

        public void StartMovement()
        {
            StopMovement();
            StartCoroutine(RunMovementMethod);
        }

        public void StopMovement()
        {
            StopCoroutine(RunMovementMethod);
        }

        private IEnumerator RunMovement()
        {
            var nextFrame = new WaitForEndOfFrame();

            while (true)
            {
                transform.Rotate(_direction * axisRotationSpeeds * Time.deltaTime);
                yield return nextFrame;
            }
        }

        public void Reverse()
        {
            _direction = -_direction;
        }
    }
}