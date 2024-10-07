using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteract : MonoBehaviour
{
    public void Interact()
    {
        if (!pauseUI.Instance.gameObject.activeSelf)
        {
            if (!InventoryUI.Instance.gameObject.activeSelf)
            {
                if (!settingUI.Instance.gameObject.activeSelf)
                {
                    if (!boxUI.Instance.gameObject.activeSelf)
                    {
                        boxUI.Instance.Show();
                        RotateToMouse.Instance.anglepause = false;
                        RotateToMouse.Instance.pause = false;
                        Debug.Log("Interact with Box");
                    }
                    else
                    {
                        boxUI.Instance.Hide();
                        RotateToMouse.Instance.anglepause = true;
                        RotateToMouse.Instance.pause = true;
                    }
                }
            }
        }
    }
}
