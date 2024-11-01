using System.Collections;
using TMPro;
using UnityEngine;

public class storyNail : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private GameObject mirror;
    
    public static storyNail Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    public void ss()
    {
        StartCoroutine(sto1());
    }
    
    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(0.1f);
        StoryLineUI.Instance.Show();
        storyText.text = "주인공 : 이 못도 제물이겠지?";
        mirror.gameObject.SetActive(true);
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.2f);
        storyText.text = "주인공 : 그럼 마지막 1개만 남았네";
        StartCoroutine(sto3());
    }
    
    private IEnumerator sto3()
    {
        yield return new WaitForSeconds(1.2f);
        storyText.text = "주인공 : 빨리 찾아서 나갈 방법을 찾자";
        StartCoroutine(sto4());
    }

    private IEnumerator sto4()
    {
        yield return new WaitForSeconds(1.2f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
