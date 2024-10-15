using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startMemuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button settingssButton;
    [SerializeField] private Button exitbutton2;
    public static startMemuUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        startButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetFloat("BGM", settingUI.Instance.BGMSlider.value);
            PlayerPrefs.SetFloat("Effect", settingUI.Instance.EffectSlider.value);
            SceneManager.LoadScene("Mainlobby");
        });
        exitButton.onClick.AddListener(() => { Application.Quit(); });
        settingButton.onClick.AddListener(() => { settingUI.Instance.Show(); });
        settingssButton.onClick.AddListener(() =>
        {
            settingUI.Instance.Hide();
            player.Instance.ui = false;
        });
        exitbutton2.onClick.AddListener(() => { Application.Quit(); });
    }

    private void Start()
    {
        settingUI.Instance.BGMSlider.value = PlayerPrefs.GetFloat("BGM");
        settingUI.Instance.EffectSlider.value = PlayerPrefs.GetFloat("Effect");
    }

    private void Update()
    {
        soundManager.Instance.walkAudioSource.Stop();
        soundManager.Instance.runAudioSource.Stop();
        RotateToMouse.Instance.anglepause = false;
        RotateToMouse.Instance.pause = false;
        player.Instance.h = 0;
        player.Instance.v = 0;
        if (Input.GetKeyDown(KeyCode.Escape)) settingUI.Instance.Hide();
        boxUI.Instance.gameObject.SetActive(false);
        OpenChestUI.Instance.gameObject.SetActive(false);
    }
}