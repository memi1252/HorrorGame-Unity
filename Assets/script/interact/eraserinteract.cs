using UnityEngine;

public class eraserinteract : MonoBehaviour
{
    public void Interact()
    {
        player.Instance.isEraser = true;
        storyEraser.Instance.dd();
        InventoryUI.Instance.eraser = true;
    }
}