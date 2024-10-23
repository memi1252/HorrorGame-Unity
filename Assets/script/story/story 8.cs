using System.Collections;
using TMPro;
using UnityEngine;

public class story8 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryLineUI.Instance.Show();
            storyText.text = "주인공 : 저게 제단인가?.";
            StartCoroutine(sto1());
        }
    }

    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 빨리 가보자!";
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.5f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
