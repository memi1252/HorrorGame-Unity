using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class storyEraser : MonoBehaviour
{
    public static storyEraser Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private TextMeshProUGUI storyText;


    public void dd()
    {
        StartCoroutine(sto1());
    }

    IEnumerator sto1()
    {
        yield return new WaitForSeconds(0f);
        StoryLineUI.Instance.Show();
        storyText.text = "시스템 : 지우게를 획득했다!";
        StartCoroutine(sto2());
    }
    
    IEnumerator sto2()
    {
        yield return new WaitForSeconds(1f);
        storyText.text = "주인공 : ??....뭐지 이 지우게는?";
        StartCoroutine(sto3());
    }
    
    IEnumerator sto3()
    {
        yield return new WaitForSeconds(1f);
        storyText.text = "주인공 : 일단 챙겨 놓자";
        StartCoroutine(sto4());
    }
    IEnumerator sto4()
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
