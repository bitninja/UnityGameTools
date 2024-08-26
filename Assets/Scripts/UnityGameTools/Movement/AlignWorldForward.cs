using UnityEngine;

namespace UnityGameTools
{
    public class AlignWorldForward : MonoBehaviour
    {
        public Vector3 worldForward = Vector3.forward;

        void LateUpdate()
        {
            transform.forward = worldForward;
        }
    }
}