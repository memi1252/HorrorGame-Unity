using UnityEngine;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    ///     Destroy GameObjects upon collision
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class Despawner : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);
        }
    }
}