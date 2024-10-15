using UnityEngine;

public class mirrorInteract : MonoBehaviour
{
    public static mirrorInteract Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Interact()
    {
        InventoryUI.Instance.mirror = true;
    }
}