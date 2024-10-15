using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    ///     Use physics raycast hit from mouse click to set agent destination
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavigationLoop : MonoBehaviour
    {
        public Transform[] goals = new Transform[3];
        private NavMeshAgent m_Agent;
        private int m_NextGoal = 1;

        private void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            var distance = Vector3.Distance(m_Agent.transform.position, goals[m_NextGoal].position);
            if (distance < 0.5f) m_NextGoal = m_NextGoal != 2 ? m_NextGoal + 1 : 0;
            m_Agent.destination = goals[m_NextGoal].position;
        }
    }
}