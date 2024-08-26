using UnityEngine;

namespace UnityGameTools
{
    public class AlignToTransform : MonoBehaviour
    {
        public Transform alignWith;

        void LateUpdate()
        {
            if (alignWith == null) return;
            transform.rotation = alignWith.rotation;
        }
    }
}