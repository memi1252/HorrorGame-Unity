using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EstereggUI : MonoBehaviour
{
    public static EstereggUI Instance { get; private set; }
    
    [SerializeField] private Button replayButton;
    [SerializeField] private Button endingButton;
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        Hide();
        Instance = this;
        replayButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetFloat("BGM", settingUI.Instance.BGMSlider.value);
            PlayerPrefs.SetFloat("Effect", settingUI.Instance.EffectSlider.value);
            Time.timeScale = 1;
            RotateToMouse.Instance.pause = true;
            LoadingBar.LoadScene("Mainlobby");
        });
        endingButton.onClick.AddListener(() =>
        {
            soundManager.Instance.audioSource.Stop();
            soundManager.Instance.walkAudioSource.Stop();
            soundManager.Instance.runAudioSource.Stop();
            Time.timeScale = 1;
            LoadingBar.LoadScene("finalScene");
        });
        continueButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            soundManager.Instance.audioSource.Play();
            RotateToMouse.Instance.pause = true;
            Hide();
        });
    }

    public void Show()
    {
        gameObject.SetActive(true);
        pauseUI.Instance.Hide();
        RotateToMouse.Instance.pause = false;
    }

    public void Hide()
    {
        RotateToMouse.Instance.pause = true;
        gameObject.SetActive(false);
    }
}
