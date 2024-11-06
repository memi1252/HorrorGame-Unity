using UnityEngine;
using UnityEngine.UI;

public class settingUI : MonoBehaviour
{
    [SerializeField] public Slider BGMSlider;
    [SerializeField] public Slider EffectSlider;
    public static settingUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Hide();
    }

    private void Update()
    {
        player.Instance.h = 0;
        player.Instance.v = 0;
        soundManager.Instance.walkAudioSource.Stop();
        soundManager.Instance.runAudioSource.Stop();
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.ui = true;
        player.Instance.v = 0;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}