using UnityEngine;

namespace UnityGameTools
{
    public class AlignToZeroRotation : MonoBehaviour
    {
        void LateUpdate()
        {
            transform.rotation = Quaternion.identity;
        }
    }
}