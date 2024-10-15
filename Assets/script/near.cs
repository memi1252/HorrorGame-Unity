using UnityEngine;

public class near : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private void OnTriggerExit(Collider other)
    {
        UI.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        UI.SetActive(true);
    }
}