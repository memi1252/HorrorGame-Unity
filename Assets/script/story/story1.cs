using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class story1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryLineUI.Instance.Show();
            storyText.text = "주인공 : 애들아 어디야,, 무서워";
            StartCoroutine(sto1());
        }
    }

    IEnumerator sto1()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "아 너무 추워,,";
        StartCoroutine(sto2());
    }
    IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "길 따라가다보면 만날수있겠지,,,";
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
