using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startMemuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button settingssButton;

    private void Awake()
    {
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
    }

    private void Start()
    {
        settingUI.Instance.BGMSlider.value = PlayerPrefs.GetFloat("BGM");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingUI.Instance.Hide();
        }
    }
}
