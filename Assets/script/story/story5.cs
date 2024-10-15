using System.Collections;
using TMPro;
using UnityEngine;

public class story5 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private Material skybox;
    public static story5 Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    public void startt()
    {
        StartCoroutine(sto0());
        RenderSettings.skybox = skybox;
    }

    private IEnumerator sto0()
    {
        yield return new WaitForSeconds(1f);
        StoryLineUI.Instance.Show();
        storyText.text = "주인공 : 뭐야 아까 그,,";
        StartCoroutine(sto1());
    }

    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 혹시 일기장에 적힌 괴물!!";
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 또 나오기전에 도망가자!!";
        StartCoroutine(sto3());
    }

    private IEnumerator sto3()
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