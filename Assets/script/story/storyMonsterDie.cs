using System.Collections;
using TMPro;
using UnityEngine;

public class storyMonsterDie : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject DirLight;
    [SerializeField] private Material sunSkyBox;
    [SerializeField] private GameObject[] frend = new GameObject[2];
    
    public static storyMonsterDie Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        car.SetActive(false);
    }

    public void ss()
    {
        StartCoroutine(sto1());
        DirLight.gameObject.SetActive(true);
        DirLight.transform.Rotate(40, 0, 0);
    }
    
    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(0.1f);
        StoryLineUI.Instance.Show();
        storyText.text = "주인공 : 어 봉인된 건가?";
        DirLight.transform.Rotate(40, 0, 0);
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(3f);
        storyText.text = "주인공 : 어,,, ";
        DirLight.transform.GetComponent<Light>().enabled = true;
        DirLight.transform.GetComponent<Light>().intensity = 1;
        DirLight.transform.Rotate(40, 0, 0);
        StartCoroutine(sto3());
    }
    
    private IEnumerator sto3()
    {
        yield return new WaitForSeconds(3f);
        storyText.text = "주인공 : 어 아침이 되고 있어!!";
        DirLight.gameObject.SetActive(true);
        DirLight.transform.Rotate(40, 0, 0);
        StartCoroutine(sto4());
    }
    
    
    private IEnumerator sto4()
    {
        yield return new WaitForSeconds(3f);
        storyText.text = "주인공 : 드디어 나갈 수 있는 건가?";
        RenderSettings.skybox = sunSkyBox;
        DirLight.transform.Rotate(30, 0, 0);
        StartCoroutine(sto5());
    }
    
    private IEnumerator sto5()
    {
        yield return new WaitForSeconds(3f);
        car.SetActive(true);
        player.Instance.gameObject.GetComponent<LookAtCamera>().enabled = true;
        player.Instance.gameObject.GetComponent<LookAtCamera>().monster1 =
            player.Instance.gameObject.GetComponent<LookAtCamera>().frend;
        storyText.text = "친구들 : 야 너 어디 갔었어 한참 찾았잖아.";
        StartCoroutine(sto6());
    }
    
    private IEnumerator sto6()
    {
        yield return new WaitForSeconds(3f);
        player.Instance.gameObject.GetComponent<LookAtCamera>().enabled = false;
        storyText.text = "주인공 : 엉엉 애들아 나 무서웠어.";
        StartCoroutine(sto7());
    }
    
    private IEnumerator sto7()
    {
        yield return new WaitForSeconds(3f);
        storyText.text = "주인공 : 아니 무슨 일이 있었냐면 (생략).";
        StartCoroutine(sto8());
    }
    
    private IEnumerator sto8()
    {
        yield return new WaitForSeconds(3f);
        storyText.text = "친구들 : 먼 소리야 이상한 소리 말고 돌아가자.";
        StartCoroutine(sto9());
    }
    
    private IEnumerator sto9()
    {
        yield return new WaitForSeconds(3f);
        storyText.text = "주인공 : 아니 내 말 좀 들어줘,,,";
        StartCoroutine(sto10());
    }

    private IEnumerator sto10()
    {
        yield return new WaitForSeconds(3f);
        storyText.text = "친구들 : 야 빨리 타!";
        frend[0].SetActive(false);
        frend[1].SetActive(false);
        StartCoroutine(sto11());
    }

    private IEnumerator sto11()
    {
        yield return new WaitForSeconds(3f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
