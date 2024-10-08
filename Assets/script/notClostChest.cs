using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class notClostChestInteract : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    
    public void Interact()
    {
        StoryLineUI.Instance.Show();
        storyText.text = "시스템 : 상자가 닫혀있다.";
        StartCoroutine(dd());
    }

    IEnumerator dd()
    {
        yield return new WaitForSeconds(1f);
        StoryLineUI.Instance.Hide();
    }
}
