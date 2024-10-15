using UnityEngine;

public class offeringInteract : MonoBehaviour
{
    public static offeringInteract Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }
    

    public void Interact()
    {
        if (!pauseUI.Instance.gameObject.activeSelf)
            if (!InventoryUI.Instance.gameObject.activeSelf)
                if (!settingUI.Instance.gameObject.activeSelf)
                {
                    if (!offeringUI.Instance.gameObject.activeSelf)
                    {
                        offeringUI.Instance.Show();
                        RotateToMouse.Instance.anglepause = false;
                        RotateToMouse.Instance.pause = false;
                        player.Instance.move = false;
                    }
                    else
                    {
                        offeringUI.Instance.Hide();
                        RotateToMouse.Instance.anglepause = true;
                        RotateToMouse.Instance.pause = true;
                        player.Instance.ui = false;
                        player.Instance.move = true;
                    }
                }
    }
}