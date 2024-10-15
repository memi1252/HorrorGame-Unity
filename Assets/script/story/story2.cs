using System.Collections;
using TMPro;
using UnityEngine;

public class story2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryLineUI.Instance.Show();
            storyText.text = "주인공 : 너무 어두워,,,";
            StartCoroutine(sto1());
        }
    }

    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(2.5f);
        storyText.text = "주인공 : 이상한 소리가 들리는데 기분탓 인가,,";
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(2.5f);
        storyText.text = "주인공 : 일딴 계속 가보자";
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