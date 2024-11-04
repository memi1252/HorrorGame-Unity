using UnityEngine;
using UnityEngine.UI;

public class DiaryUI : MonoBehaviour
{
    public static DiaryUI Instance { get; private set; }
    
    public bool isdiary = false;


    private void Awake()
    {
        Instance = this;
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
        player.Instance.ui = true;
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.v = 0;
        RotateToMouse.Instance.anglepause = false;
        RotateToMouse.Instance.pause = false;
        Time.timeScale = 0;
        isdiary = true;
    }


    public void Hide()
    {
        player.Instance.ui = false;
        Time.timeScale = 1;
        RotateToMouse.Instance.anglepause = true;
        RotateToMouse.Instance.pause = true;
        gameObject.SetActive(false);
    }
}