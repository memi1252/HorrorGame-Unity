using UnityEngine;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    ///     Component for moving GameObjects within a NavMesh.
    ///     Requests a NavMesh update whenever its owning GameObject has stopped moving.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(NavMeshModifier))]
    public class DynamicNavMeshObject : MonoBehaviour
    {
        private NavMeshModifier m_NavMeshModifier;
        private Rigidbody m_Rigidbody;
        private bool m_WasMoving;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_NavMeshModifier = GetComponent<NavMeshModifier>();
            m_NavMeshModifier.enabled = true;
            m_WasMoving = !m_Rigidbody.IsSleeping();
        }

        private void Update()
        {
            var isMoving = !m_Rigidbody.IsSleeping() && m_Rigidbody.linearVelocity.sqrMagnitude > 0.1f;

            if ((m_WasMoving && !isMoving) || (!m_WasMoving && isMoving))
            {
                m_NavMeshModifier.ignoreFromBuild = isMoving;
                GloballyUpdatedNavMeshSurface.RequestNavMeshUpdate();
            }

            m_WasMoving = isMoving;
        }
    }
}