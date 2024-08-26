using UnityEngine;

namespace UnityGameTools
{
    public enum WaveType { Sine, Triangle, Square }
    public class OscillatingMovement : MonoBehaviour
    {
        [Tooltip("The starting position of the oscillation.")]
        public Vector3 startPosition;

        [Tooltip("The stopping position of the oscillation.")]
        public Vector3 stopPosition;

        [Tooltip("If true, the oscillation will be relative to the object's current position. Otherwise start and stop are absolute positions")]
        public bool isRelative;

        [Tooltip("The type of wave used for oscillating the object.")]
        public WaveType waveType;

        [Tooltip("The duration of one complete oscillation cycle in seconds.")]
        public float cycleSeconds;

        private float _startTime;
        private Vector3 _center;
        private Vector3 _midpoint;
        private Vector3 _diffVec;

        public void SetStartPosition(Vector3 startPos)
        {
            startPosition = startPos;
        }

        public void SetStopPosition(Vector3 stopPos)
        {
            stopPosition = stopPos;
        }

        public void SetIsRelative(bool relative)
        {
            isRelative = relative;
        }

        public void SetWaveType(WaveType wave)
        {
            waveType = wave;
        }

        public void SetCycleSeconds(float seconds)
        {
            cycleSeconds = seconds;
        }


        void Start()
        {
            _startTime = Time.time;

            _diffVec = stopPosition - startPosition;
            _midpoint = .5f * _diffVec;
            _center = isRelative ? transform.position : _midpoint;
        }

        void Update()
        {
            var functionTime = (Time.time - _startTime) % cycleSeconds;
            switch (waveType)
            {
                case WaveType.Sine:
                    transform.position = _center + _midpoint * Mathf.Sin(2 * Mathf.PI * 1 / cycleSeconds * (Time.time - _startTime));
                    break;
                case WaveType.Triangle:
                    transform.position = _center + _midpoint * (1f - Mathf.PingPong((functionTime - cycleSeconds / 4) * 2f, 2));
                    break;
                case WaveType.Square:
                    transform.position = _center + ((functionTime < .5f * cycleSeconds) ? 1f : -1f) * _midpoint;
                    break;
                default:
                    // Safety check for if another WaveType is added but not handled.
                    Debug.LogWarning($"Unhandled WaveType = {waveType}");
                    break;
            }
        }
    }
}