using UnityEngine;

namespace UnityGameTools
{
	public class AxisGizmo : MonoBehaviour
	{
		public float rightSize = 1f;
		public float upSize = 1f;
		public float forwardSize = 1f;

		void OnDrawGizmos()
		{
			// Draws axis pointers for only positive direction.  The goal was to provide
			// indication of direction without being too obnoxious (i.e. showing both
			// positive and negative).

			var center = transform.position;

			Gizmos.color = Color.red;
			Gizmos.DrawLine(center + transform.right * rightSize, center);

			Gizmos.color = Color.green;
			Gizmos.DrawLine(center + transform.up * upSize, center);

			Gizmos.color = Color.blue;
			Gizmos.DrawLine(center + transform.forward * forwardSize, center);

			Gizmos.color = Color.white;
		}
	}
}