using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseUI : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingButton;

    public bool pauseUIpasue;
    public static pauseUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        exitButton.onClick.AddListener(() =>
        {
            if (!storysign.Instance.esteregg)
            {
                PlayerPrefs.SetFloat("BGM", settingUI.Instance.BGMSlider.value);
                PlayerPrefs.SetFloat("Effect", settingUI.Instance.EffectSlider.value);
                SceneManager.LoadScene("main");
            }
            else
            {
                Time.timeScale = 0;
                EstereggUI.Instance.Show();
                soundManager.Instance.audioSource.Stop();
                soundManager.Instance.walkAudioSource.Stop();
                soundManager.Instance.runAudioSource.Stop();
            }
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

    private void Update()
    {
        soundManager.Instance.walkAudioSource.Stop();
        soundManager.Instance.runAudioSource.Stop();
        player.Instance.h = 0;
        player.Instance.v = 0;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.v = 0;
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