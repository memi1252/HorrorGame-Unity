using System.Collections;
using TMPro;
using UnityEngine;

public class storyMonsterDie : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject DirLight;
    
    public static storyMonsterDie Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        car.SetActive(false);
    }

    public void ss()
    {
        StartCoroutine(sto1());
        DirLight.transform.Rotate(20, 0, 0);
    }
    
    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(0.1f);
        StoryLineUI.Instance.Show();
        storyText.text = "주인공 : 어 봉인 된건가?";
        DirLight.transform.Rotate(20, 0, 0);
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "주인공 : 어,,, ";
        DirLight.transform.Rotate(20, 0, 0);
        StartCoroutine(sto3());
    }
    
    private IEnumerator sto3()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "주인공 : 어 아침이 되고 있어!!";
        DirLight.transform.Rotate(20, 0, 0);
        car.SetActive(true);
        StartCoroutine(sto4());
    }
    
    
    private IEnumerator sto4()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "주인공 : 드디어 나갈수 있는건가?";
        DirLight.transform.Rotate(15, 0, 0);
        car.SetActive(true);
        StartCoroutine(sto5());
    }
    
    private IEnumerator sto5()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "친구들 : 야 너 어디갔었어 한참 찾았잖아";
        StartCoroutine(sto6());
    }
    
    private IEnumerator sto6()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "주인공 : 아 미안 길을 잊어버려서 ㅎㅎ";
        StartCoroutine(sto7());
    }
    
    private IEnumerator sto7()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "주인공 : 나 너무추운데 일단 집으로 갈까?";
        StartCoroutine(sto8());
    }
    
    private IEnumerator sto8()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "친구들 : 그래 빨리 가자";
        StartCoroutine(sto9());
    }

    private IEnumerator sto9()
    {
        yield return new WaitForSeconds(2f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}