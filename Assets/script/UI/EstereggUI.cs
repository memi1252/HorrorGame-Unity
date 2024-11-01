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
            SceneManager.LoadScene("Mainlobby");
        });
        endingButton.onClick.AddListener(() =>
        {
            soundManager.Instance.audioSource.Stop();
            soundManager.Instance.walkAudioSource.Stop();
            soundManager.Instance.runAudioSource.Stop();
            Time.timeScale = 1;
            SceneManager.LoadScene("finalScene");
        });
        continueButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            soundManager.Instance.audioSource.Play();
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
