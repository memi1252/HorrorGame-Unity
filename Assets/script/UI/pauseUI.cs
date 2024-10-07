using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseUI : MonoBehaviour
{
    public static pauseUI Instance { get; private set; }

    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingButton;

    public bool pauseUIpasue;

    private void Awake()
    {
        Instance = this;
        
        exitButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetFloat("BGM", settingUI.Instance.BGMSlider.value);
            SceneManager.LoadScene("main");
        });
        settingButton.onClick.AddListener(() =>
        {
            if (!InventoryUI.Instance.gameObject.activeSelf && !boxUI.Instance.gameObject.activeSelf)
            {
                settingUI.Instance.Show();
                Hide();
                pauseUIpasue = true;
            }
        });
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        pauseUIpasue = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        pauseUIpasue = false;
    }
}
