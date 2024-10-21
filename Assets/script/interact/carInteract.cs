using UnityEngine;

public class carInteract : MonoBehaviour
{
    [SerializeField] private GameObject carCamera;
    public void Interact()
    {
        carCamera.SetActive(true);
        carmove.Instance.iscar = true;
    }
}
