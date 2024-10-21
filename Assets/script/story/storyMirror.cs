using System.Collections;
using TMPro;
using UnityEngine;

public class storyMirror : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    
    public static storyMirror Instance { get; private set; }


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
        storyText.text = "주인공 : 거울,";
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.3f);
        storyText.text = "주인공 : 나 좀 잘생겼는데 ㅎㅎ";
        StartCoroutine(sto3());
    }
    
    private IEnumerator sto3()
    {
        yield return new WaitForSeconds(1.3f);
        storyText.text = "주인공 : 아 이렇떄가 아니지";
        StartCoroutine(sto4());
    }
    
    private IEnumerator sto4()
    {
        yield return new WaitForSeconds(1.3f);
        storyText.text = "주인공 : 빨리 제단으로가자";
        StartCoroutine(sto5());
    }
    
    
    private IEnumerator sto5()
    {
        yield return new WaitForSeconds(1.3f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
