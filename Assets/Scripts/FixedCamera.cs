using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRobEngine
{
    [CreateAssetMenu(menuName = "SRobEngine/Cameras/FixedCamera")]
    public class FixedCamera : ScriptableObject
    {
        [SerializeField] Vector3 position;
        [SerializeField] Vector3 rotation;

#if UNITY_EDITOR

        [Header("Preview")]

        public float pointSize = 0.1f;
        public Color color;
        public bool preview = false;

        public void PreviewCamera()
        {
            if(preview)
            {
                DrawPointGizmo();
                Camera.main.transform.position = position;
                Camera.main.transform.rotation = Quaternion.Euler(rotation);
            }
        }

        public void DrawPointGizmo()
        {
            Gizmos.color = color;
            Gizmos.matrix = Matrix4x4.Translate(position) * Matrix4x4.Rotate(Quaternion.Euler(rotation));
            Gizmos.DrawCube(Vector3.zero, Vector3.one * pointSize);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3.forward);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(Vector3.zero, Vector3.up);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3.right);
            Gizmos.matrix = Matrix4x4.identity;
        }
#endif
    }
}
