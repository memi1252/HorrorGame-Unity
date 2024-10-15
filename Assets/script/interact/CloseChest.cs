using System.Collections;
using TMPro;
using UnityEngine;

public class CloseChestInteract : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;

    public void Interact()
    {
        StoryLineUI.Instance.Show();
        storyText.text = "시스템 : 상자가 닫혀있다.";
        StartCoroutine(dd());
    }

    private IEnumerator dd()
    {
        yield return new WaitForSeconds(0.6f);
        StoryLineUI.Instance.Hide();
    }
}