using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button clostButton;
    public static StoryUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        playButton.onClick.AddListener(() =>
        {
            Hide();
            Time.timeScale = 1;
            RotateToMouse.Instance.anglepause = true;
            //flash.Instance.pickUpFlash = false;
            SceneManager.LoadScene("Map");
        });
        clostButton.onClick.AddListener(() =>
        {
            Hide();
            Time.timeScale = 1;
            RotateToMouse.Instance.anglepause = true;
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
        player.Instance.ui = true;
        player.Instance.v = 0;
        RotateToMouse.Instance.pause = false;
    }


    public void Hide()
    {
        gameObject.SetActive(false);
        player.Instance.ui = false;
        RotateToMouse.Instance.pause = true;
    }
}