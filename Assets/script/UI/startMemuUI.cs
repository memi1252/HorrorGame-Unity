using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startMemuUI : MonoBehaviour
{
    public static startMemuUI Instance { get; private set; }
    
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button settingssButton;
    [SerializeField] private Button exitbutton2;

    private void Awake()
    {
        Instance = this;
        startButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetFloat("BGM", settingUI.Instance.BGMSlider.value);
            SceneManager.LoadScene("Mainlobby");
        });
        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        settingButton.onClick.AddListener(() =>
        {
            settingUI.Instance.Show();
        });
        settingssButton.onClick.AddListener(() =>
        {
            settingUI.Instance.Hide();
        });
        exitbutton2.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void Start()
    {
        settingUI.Instance.BGMSlider.value = PlayerPrefs.GetFloat("BGM");
    }

    private void Update()
    {
        RotateToMouse.Instance.anglepause = false;
        RotateToMouse.Instance.pause = false;
        player.Instance.h = 0;
        player.Instance.v =0;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingUI.Instance.Hide();
        }
    }
}
