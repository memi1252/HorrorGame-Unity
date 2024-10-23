using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finalUI : MonoBehaviour
{
    public static finalUI Instance { get; private set; }
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;

    private void Awake()
    {
        Instance = this;
        Hide();
        button1.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Mainlobby");
        });
        button2.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("main");
        });
    }

    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(Text1());
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Text1()
    {
        yield return new WaitForSeconds(1f);
        text1.SetActive(true);
        StartCoroutine(Text2());
    }

    IEnumerator Text2()
    {
        yield return new WaitForSeconds(2f);
        text1.SetActive(false);
        text2.SetActive(true);
        StartCoroutine(Text3());
    }

    IEnumerator Text3()
    {
        yield return new WaitForSeconds(2f);
        text2.SetActive(false);
        text3.SetActive(true);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
    }

}
