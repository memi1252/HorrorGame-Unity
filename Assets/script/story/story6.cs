using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class story6 : MonoBehaviour
{
    public static story6 Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI storyText;


    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryLineUI.Instance.Show();
            storyText.text = "주인공 : 이 상자들 뭐지??";
            StartCoroutine(sto1());
        }
    }
    
    IEnumerator sto1()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 상자 안에 제물이 있을지 모르니 일단 열어보자";
        StartCoroutine(sto2());
    }
    
    IEnumerator sto2()
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