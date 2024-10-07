using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class story5 : MonoBehaviour
{
    public static story5 Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI storyText;


    private void Awake()
    {
        Instance = this;
    }

    public void startt()
    {
        
        StartCoroutine(sto0());
    }

    IEnumerator sto0()
    {
        yield return new WaitForSeconds(1f);
        StoryLineUI.Instance.Show();
        storyText.text = "주인공 : 뭐야 아까 그,,";
        StartCoroutine(sto1());
    }
    
    IEnumerator sto1()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 혹시 일기장에 적힌 괴물!!";
        StartCoroutine(sto2());
    }
    IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 빨리 나머지 아이템이랑 제단을 찾아야해!!";
        StartCoroutine(sto3());
    }
    IEnumerator sto3()
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
