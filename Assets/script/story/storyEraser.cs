using System.Collections;
using TMPro;
using UnityEngine;

public class storyEraser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    public static storyEraser Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public void dd()
    {
        StartCoroutine(sto1());
    }

    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(0f);
        StoryLineUI.Instance.Show();
        storyText.text = "시스템 : 지우개를 획득했다!";
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(1f);
        storyText.text = "주인공 : ??.... 뭐지 이 지우개는?";
        StartCoroutine(sto3());
    }

    private IEnumerator sto3()
    {
        yield return new WaitForSeconds(1f);
        storyText.text = "주인공 : 일단 챙겨 놓자.";
        StartCoroutine(sto4());
    }

    private IEnumerator sto4()
    {
        yield return new WaitForSeconds(1f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}