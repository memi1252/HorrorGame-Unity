using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    ///     Manipulation tool for displacing the vertices in a list of meshes
    /// </summary>
    [DefaultExecutionOrder(-101)]
    public class MeshTool : MonoBehaviour
    {
        public enum ExtrudeMethod
        {
            Vertical,
            MeshNormal
        }

        public List<MeshFilter> m_Filters = new();
        public float m_Radius = 1.5f;
        public float m_Power = 2.0f;
        public ExtrudeMethod m_Method = ExtrudeMethod.Vertical;

        private RaycastHit m_HitInfo;
        private AsyncOperation m_LastNavMeshUpdate;
        private NavMeshSurface m_Surface;

        private void Update()
        {
            var ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
            {
                Debug.DrawRay(m_HitInfo.point, m_HitInfo.normal, Color.red);
                var displacement = m_Method == ExtrudeMethod.Vertical ? Vector3.up : m_HitInfo.normal;

                if (Input.GetMouseButton(0) || (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift)))
                {
                    ModifyMesh(m_Power * displacement, m_HitInfo.point);
                    if (m_Surface != null)
                        if (m_LastNavMeshUpdate.isDone)
                            m_LastNavMeshUpdate = m_Surface.UpdateNavMesh(m_Surface.navMeshData);
                }
                else if (Input.GetMouseButton(1) || (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift)))
                {
                    ModifyMesh(-m_Power * displacement, m_HitInfo.point);
                    if (m_Surface != null)
                        if (m_LastNavMeshUpdate.isDone)
                            m_LastNavMeshUpdate = m_Surface.UpdateNavMesh(m_Surface.navMeshData);
                }
                else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.Space))
                {
                    if (m_Surface != null)
                    {
                        if (!m_LastNavMeshUpdate.isDone)
                            NavMeshBuilder.Cancel(m_Surface.navMeshData);

                        m_LastNavMeshUpdate = m_Surface.UpdateNavMesh(m_Surface.navMeshData);
                    }
                }
            }
        }

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            m_Surface = GetComponent<NavMeshSurface>();
            if (m_Surface != null)
            {
                m_Surface.BuildNavMesh();
                m_LastNavMeshUpdate = m_Surface.UpdateNavMesh(m_Surface.navMeshData);
            }
        }

        private void ModifyMesh(Vector3 displacement, Vector3 center)
        {
            foreach (var filter in m_Filters)
            {
                var mesh = filter.mesh;
                var vertices = mesh.vertices;

                for (var i = 0; i < vertices.Length; ++i)
                {
                    var v = filter.transform.TransformPoint(vertices[i]);
                    vertices[i] = vertices[i] + displacement * Gaussian(v, center, m_Radius);
                }

                mesh.vertices = vertices;
                mesh.RecalculateBounds();

                var col = filter.GetComponent<MeshCollider>();
                if (col != null)
                {
                    var colliMesh = new Mesh();
                    colliMesh.vertices = mesh.vertices;
                    colliMesh.triangles = mesh.triangles;
                    col.sharedMesh = colliMesh;
                }
            }
        }

        private static float Gaussian(Vector3 pos, Vector3 mean, float dev)
        {
            var x = pos.x - mean.x;
            var y = pos.y - mean.y;
            var z = pos.z - mean.z;
            var n = 1.0f / (2.0f * Mathf.PI * dev * dev);
            return n * Mathf.Pow(2.718281828f, -(x * x + y * y + z * z) / (2.0f * dev * dev));
        }
    }
}