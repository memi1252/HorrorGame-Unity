using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorInteract : MonoBehaviour
{
    public void Interact()
    {
        InventoryUI.Instance.mirror = true;
    }
}
