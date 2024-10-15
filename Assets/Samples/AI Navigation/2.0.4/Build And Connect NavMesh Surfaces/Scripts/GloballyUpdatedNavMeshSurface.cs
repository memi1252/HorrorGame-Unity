using UnityEngine;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    ///     NavMeshSurface that updates only once per frame upon request
    /// </summary>
    [RequireComponent(typeof(NavMeshSurface))]
    public class GloballyUpdatedNavMeshSurface : MonoBehaviour
    {
        private static bool s_NeedsNavMeshUpdate;

        private NavMeshSurface m_Surface;

        private void Start()
        {
            m_Surface = GetComponent<NavMeshSurface>();
            m_Surface.BuildNavMesh();
        }

        private void Update()
        {
            if (s_NeedsNavMeshUpdate)
            {
                m_Surface.UpdateNavMesh(m_Surface.navMeshData);
                s_NeedsNavMeshUpdate = false;
            }
        }

        public static void RequestNavMeshUpdate()
        {
            s_NeedsNavMeshUpdate = true;
        }
    }
}