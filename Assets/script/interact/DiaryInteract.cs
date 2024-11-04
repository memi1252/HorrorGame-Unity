using UnityEngine;

public class DiaryInteract : MonoBehaviour
{
    public void Interact()
    {
        if (DiaryUI.Instance.gameObject.activeSelf)
        {
            DiaryUI.Instance.Hide();
        }
        else
        {
            DiaryUI.Instance.Show();
        }
    }
}