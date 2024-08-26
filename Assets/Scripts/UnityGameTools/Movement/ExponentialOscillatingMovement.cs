using System.Collections;
using UnityEngine;

namespace UnityGameTools
{
    public class ExponentialOscillatingMovement : MonoBehaviour
    {
        public enum RotationAxis { X, Y, Z }

        private static readonly string OscillatingMethod = "Oscillating";

        [Tooltip("How many times per second the oscillation goes from start to finish.")]
        public float frequency = 10;

        [Tooltip("How long in seconds it takes to reach the zeroTolerance value.")]
        public float decayTime = .2f;

        [Tooltip("This is the target amplitude value for the specified decay time.")]
        public float zeroTolerance = .01f;

        [Tooltip("How many times per second the oscillation goes from start to finish.")]
        public float peakValue = 100f;

        [Tooltip("Zero out the rotation after the decay time duration.")]
        public bool zeroOutOnComplete = true;

        [Tooltip("The axis to rotate around.")]
        public RotationAxis axis;

        public void StartOscillation()
        {
            StartCoroutine(OscillatingMethod);
        }

        public void EndOscillation()
        {
            StopCoroutine(OscillatingMethod);
        }

        private IEnumerator Oscillating()
        {
            var endOfFrame = new WaitForEndOfFrame();
            var startTime = Time.time;

            float time;
            while ((time = Time.time - startTime) <= decayTime)
            {
                float rotationangle = ComputeAngle(time);

                var currentRotation = transform.eulerAngles;
                transform.rotation = Quaternion.Euler(
                    axis == RotationAxis.X ? rotationangle : currentRotation.x,
                    axis == RotationAxis.Y ? rotationangle : currentRotation.y,
                    axis == RotationAxis.Z ? rotationangle : currentRotation.z);

                yield return endOfFrame;
            }

            if (zeroOutOnComplete)
            {
                var currentRotation = transform.eulerAngles;
                transform.rotation = Quaternion.Euler(
                    axis == RotationAxis.X ? 0 : currentRotation.x,
                    axis == RotationAxis.Y ? 0 : currentRotation.y,
                    axis == RotationAxis.Z ? 0 : currentRotation.z);
            }
        }

        private float ComputeAngle(float time)
        {
            if (frequency == 0) return 0f;
            var alpha = Mathf.Log(zeroTolerance) / -decayTime;
            return peakValue * Mathf.Exp(-alpha * time) * Mathf.Sin(2 * Mathf.PI * frequency * time);
        }
    }
}