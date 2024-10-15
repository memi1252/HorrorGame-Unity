using UnityEngine;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    ///     Prefab spawner with a key input
    /// </summary>
    public class SpawnPrefabOnKeyDown : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        [SerializeField] private KeyCode keyCode;

        [SerializeField] private Transform spawnedPrefabsHolder;

        private Transform m_Transform;

        private void Start()
        {
            m_Transform = transform;

            if (spawnedPrefabsHolder == null) spawnedPrefabsHolder = m_Transform;
        }

        private void Update()
        {
            if (Input.GetKeyDown(keyCode) && prefab != null)
                Instantiate(prefab, m_Transform.position, m_Transform.rotation, spawnedPrefabsHolder);
        }
    }
}