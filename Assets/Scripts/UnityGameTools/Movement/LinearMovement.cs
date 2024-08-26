using UnityEngine;

namespace UnityGameTools
{
    public class LinearMovement : MonoBehaviour
    {
        public float upSpeed = 1;
        public float forwardSpeed = 0;
        public float rightSpeed = 0;

        public bool isRelative;

        public bool isReverse;

        public void ToggleReverse()
        {
            isReverse = !isReverse;
        }

        public void SetUpSpeed(float speed)
        {
            upSpeed = speed;
        }

        public void SetForwardSpeed(float speed)
        {
            forwardSpeed = speed;
        }

        public void SetRightSpeed(float speed)
        {
            rightSpeed = speed;
        }

        public void SetIsRelative(bool isRelative)
        {
            this.isRelative = isRelative;
        }

        public void SetReverse(bool isReverse)
        {
            this.isReverse = isReverse;
        }

        void Update()
        {
            var speed = Vector3.zero;

            if (Mathf.Abs(upSpeed) > 0)
            {
                speed += upSpeed * (isRelative ? transform.up : Vector3.up);
            }

            if (Mathf.Abs(forwardSpeed) > 0)
            {
                speed += forwardSpeed * (isRelative ? transform.forward : Vector3.forward);
            }

            if (Mathf.Abs(rightSpeed) > 0)
            {
                speed += rightSpeed * (isRelative ? transform.right : Vector3.right);
            }

            transform.position += Time.deltaTime * (isReverse ? -1f : 1f) * speed;
        }
    }
}