using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class storycityfinal : MonoBehaviour
{
    public static storycityfinal Instance { get; private set; }
    
    
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private GameObject camerasss;
    
    private void Awake()
    {
        Instance = this;
        StartCoroutine(ss());
        StartCoroutine(sto0());
        StartCoroutine(final());
    }

    private void Start()
    {
        RotateToMouse.Instance.pause = true;
    }

    IEnumerator ss()
    {
        yield return new WaitForSeconds(9f);
    }

    private IEnumerator sto0()
    {
        yield return new WaitForSeconds(2f);
        StoryLineUI.Instance.Show();
        storyText.text = "주인공 : 어,, ";
        StartCoroutine(sto1());
    }
    
    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(4f);
        storyText.text = "주인공 : 꿈이었나?";
        StartCoroutine(sto2());
    }
    
    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "주인공 : 그럼 그렇지 저런 괴물이 있겠어?";
        StartCoroutine(sto3());
    }
    
    private IEnumerator sto3()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "주인공 : 아 꿈꿔서 그런가 배고프네.";
        StartCoroutine(sto4());
    }
    
    private IEnumerator sto4()
    {
        yield return new WaitForSeconds(2f);
        camerasss.SetActive(true);
        storyText.text = "주인공 : 밥이나 먹어야겠다.";
        StartCoroutine(sto5());
    }
    
    private IEnumerator sto5()
    {
        yield return new WaitForSeconds(2f);
        storyText.text = "주인공 : 아 오늘은 뭘 먹을까?.";
        StartCoroutine(sto6());
    }
    
    private IEnumerator sto6()
    {
        yield return new WaitForSeconds(1.5f);
        StoryLineUI.Instance.Hide();
    }

    private IEnumerator final()
    {
        yield return new WaitForSeconds(22f);
        finalUI.Instance.Show();
    }
}
