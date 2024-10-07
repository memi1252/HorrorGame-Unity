using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class flashInteract : MonoBehaviour
{
    public static flashInteract Instance { get; private set; }
    [SerializeField] public Light Light;
    
    
    private void Awake()
    {
        Instance = this;
    }


    public void Interact()
    {
        GameObject flash1 = Instantiate(itemManager.Instance.item[0],player.Instance.itemPos.transform, false);
        player.Instance.itemPos.transform.position = flash1.transform.position;
        flash.Instance.pickUpFlash = true;
        Light.gameObject.SetActive(false);
        player.Instance.isFlash = true;
        InventoryUI.Instance.flash = true;
    }
}
