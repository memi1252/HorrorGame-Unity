using UnityEngine;

public class eraser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            storyEraser.Instance.dd();
            InventoryUI.Instance.eraser = true;
            Destroy(gameObject);
        }
    }
}