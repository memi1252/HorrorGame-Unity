using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieUI : MonoBehaviour
{
    [SerializeField] private Button ReStartButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private TextMeshProUGUI SurvivalTImeText;
    [SerializeField] private TextMeshProUGUI itemIndexText;
    public static DieUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        ReStartButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetFloat("BGM", settingUI.Instance.BGMSlider.value);
            PlayerPrefs.SetFloat("Effect", settingUI.Instance.EffectSlider.value);
            SceneManager.LoadScene("main");
        });
        MainMenuButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetFloat("BGM", settingUI.Instance.BGMSlider.value);
            PlayerPrefs.SetFloat("Effect", settingUI.Instance.EffectSlider.value);
            SceneManager.LoadScene("Mainlobby");
        });
    }

    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        soundManager.Instance.walkAudioSource.Stop();
        soundManager.Instance.runAudioSource.Stop();
        SurvivalTImeText.text =
            $"생존 시간 :{(int)playTime.Instance.playTimes / 60}:{(int)playTime.Instance.playTimes % 60}";
        player.Instance.h = 0;
        player.Instance.v = 0;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.v = 0;
        player.Instance.ui = true;
        pauseUI.Instance.pauseUIpasue = false;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        player.Instance.ui = false;
        pauseUI.Instance.pauseUIpasue = true;
    }
}