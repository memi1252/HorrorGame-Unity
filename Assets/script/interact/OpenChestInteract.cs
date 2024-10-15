using System.Collections;
using TMPro;
using UnityEngine;

public class OpenChestInteract : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;

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
                        StoryLineUI.Instance.Show();
                        storyText.text = "시스템 : 상자가 열렸다.";
                        StartCoroutine(HideMessage());
                    }
                    else
                    {
                        OpenChestUI.Instance.Hide();
                        player.Instance.ui = false;
                        RotateToMouse.Instance.anglepause = true;
                        RotateToMouse.Instance.pause = true;
                        player.Instance.move = true;
                    }
                }
    }

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(0.2f);
        StoryLineUI.Instance.Hide();
    }
}