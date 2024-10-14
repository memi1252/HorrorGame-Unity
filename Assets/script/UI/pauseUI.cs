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

    private void Update()
    {
        player.Instance.h = 0;
        player.Instance.v =0;
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.v =0;
        player.Instance.ui = true;
        pauseUIpasue = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        player.Instance.ui = false;
        pauseUIpasue = false;
    }
}
