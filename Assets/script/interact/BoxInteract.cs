using UnityEngine;

public class BoxInteract : MonoBehaviour
{
    public bool isShow;
    public static BoxInteract Instance { get; private set; }

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
                    if (!boxUI.Instance.gameObject.activeSelf)
                    {
                        boxUI.Instance.Show();
                        RotateToMouse.Instance.anglepause = false;
                        RotateToMouse.Instance.pause = false;
                        Debug.Log("Interact with Box");
                    }
                    else
                    {
                        if (!isShow)
                        {
                            boxCloseMonster.Instance.monstershow();
                            story5.Instance.startt();
                            isShow = true;
                        }

                        boxUI.Instance.Hide();
                        player.Instance.ui = false;
                        RotateToMouse.Instance.anglepause = true;
                        RotateToMouse.Instance.pause = true;
                    }
                }
    }
}