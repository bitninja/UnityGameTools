using UnityEngine;

namespace UnityGameTools
{
    public class AlignWorldUp : MonoBehaviour
    {
        public Vector3 worldUp = Vector3.up;

        void LateUpdate()
        {
            transform.up = worldUp;
        }
    }
}