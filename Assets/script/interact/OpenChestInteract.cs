using System.Collections;
using TMPro;
using UnityEngine;

public class OpenChestInteract : MonoBehaviour
{
    private bool dd =true;

    public void Interact()
    {
        if (!pauseUI.Instance.gameObject.activeSelf)
            if (!InventoryUI.Instance.gameObject.activeSelf)
                if (!settingUI.Instance.gameObject.activeSelf)
                {
                    if (!OpenChestUI.Instance.gameObject.activeSelf)
                    {
                        OpenChestUI.Instance.Show();
                        RotateToMouse.Instance.anglepause = false;
                        RotateToMouse.Instance.pause = false;
                        player.Instance.move = false;
                        soundManager.Instance.box1AudioSource.Play();
                    }
                    else
                    {
                        if (dd)
                        {
                            storyNail.Instance.ss();
                            dd=false;
                        }
                        OpenChestUI.Instance.Hide();
                        player.Instance.ui = false;
                        RotateToMouse.Instance.anglepause = true;
                        RotateToMouse.Instance.pause = true;
                        player.Instance.move = true;
                    }
                }
    }
}