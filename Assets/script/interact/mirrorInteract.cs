using UnityEngine;

public class mirrorInteract : MonoBehaviour
{
    public static mirrorInteract Instance { get; private set; }
    private bool ss = false;

    private void Awake()
    {
        Instance = this;
    }

    public void Interact()
    {
        InventoryUI.Instance.mirror = true;
        storyMirror.Instance.ss();
    }
}