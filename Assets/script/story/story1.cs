using System.Collections;
using TMPro;
using UnityEngine;

public class story1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryLineUI.Instance.Show();
            storyText.text = "주인공 : 애들아 어디야,, 무서워.";
            StartCoroutine(sto1());
        }
    }

    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(2.5f);
        storyText.text = "주인공 : 아 너무 추워,,";
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(2.5f);
        storyText.text = "주인공 : 길 따라가다 보면 만날 수 있겠지,,,";
        StartCoroutine(sto3());
    }

    private IEnumerator sto3()
    {
        yield return new WaitForSeconds(2.5f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}