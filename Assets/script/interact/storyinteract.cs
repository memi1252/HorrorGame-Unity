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
            pauseUI.Instance.pauseUIpasue = false;
            interact = false;
        }
        else
        {
            StoryUI.Instance.Show();
            Time.timeScale = 0;
            RotateToMouse.Instance.anglepause = false;
            pauseUI.Instance.pauseUIpasue = true;
            interact = true;
        }
    }
}