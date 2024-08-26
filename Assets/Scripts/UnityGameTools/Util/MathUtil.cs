using UnityEngine;

namespace UnityGameTools
{
    public static class MathUtil
    {
        public static float Sigmoid(float x)
        {
            return 1f / (1f + Mathf.Exp(-x));
        }

        // The sigmoid function never reaches a zero value only approximates it at infinity.
        // The zeroValueTarget provides a means of shifting the sigmoid to where at x=0 the
        // sigmoid would return the zeroValueTarget value.  By default a zero target value of .01f
        // is used, thus when the sigmoid x value of zero is given a value of .01f is returned.
        // The primary use for this is with easing functions, like an easing-camera or easing-follow.
        // The distance field provides a way of supplying a target length such that at an x value
        // of stretchDistance will return a value of 1-zeroValueTarget.
        public static float ShiftedSigmoid(float x, float zeroValueTarget = .01f, float? stretchDistance = null)
        {
            var alpha = Mathf.Log(1 / zeroValueTarget - 1);
            var mult = 1f;
            if (stretchDistance.HasValue)
            {
                mult = stretchDistance.Value / (alpha - Mathf.Log(1f / (1f - zeroValueTarget) - 1f));
            }

            return Sigmoid((x - alpha) * mult);
        }

        public static float Sqrd(this float x)
        {
            return x * x;
        }

        public static Vector3 Clamp(Vector3 val, Vector3 min, Vector3 max)
        {
            var x = Mathf.Clamp(val.x, min.x, max.x);
            var y = Mathf.Clamp(val.y, min.y, max.y);
            var z = Mathf.Clamp(val.z, min.z, max.z);

            return new Vector3(x, y, z);
        }

        public static float Ease(float duration, float tolerance, float x, bool isInverse = false)
        {
            var beta = Mathf.Log(1 / tolerance - 1f);
            var alpha = 1f / (2f * beta);
            var easeVal = 1f / (1f - Mathf.Exp(-((alpha / duration) * x - beta)));
            if (isInverse) return 1f - easeVal;
            return easeVal;
        }
    }
}