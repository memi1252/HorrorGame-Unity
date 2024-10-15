using UnityEngine;

public class storyinteract : MonoBehaviour
{
    public bool interact;
    public static storyinteract Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public void Interact()
    {
        if (StoryUI.Instance.gameObject.activeSelf)
        {
            StoryUI.Instance.Hide();
            Time.timeScale = 1;
            RotateToMouse.Instance.anglepause = true;
            interact = false;
        }
        else
        {
            StoryUI.Instance.Show();
            Time.timeScale = 0;
            RotateToMouse.Instance.anglepause = false;
            interact = true;
        }
    }
}