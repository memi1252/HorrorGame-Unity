using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject flashObject;
    [SerializeField] private GameObject eraserObject;
    [SerializeField] private GameObject crossObject;
    [SerializeField] private GameObject baseBallObject;
    [SerializeField] private GameObject nailObject;
    [SerializeField] private GameObject mirrorObject;

    public bool flash;
    public bool eraser;
    public bool cross;
    public bool baseBall;
    public bool nail;
    public bool mirror;
    public static InventoryUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        flashObject.SetActive(false);
        eraserObject.SetActive(false);
        crossObject.SetActive(false);
        baseBallObject.SetActive(false);
        nailObject.SetActive(false);
        mirrorObject.SetActive(false);
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
        if (flash)
            flashObject.SetActive(true);
        else
            flashObject.SetActive(false);
        if (eraser)
            eraserObject.SetActive(true);
        else
            eraserObject.SetActive(false);
        if (cross)
            crossObject.SetActive(true);
        else
            crossObject.SetActive(false);
        if (baseBall)
            baseBallObject.SetActive(true);
        else
            baseBallObject.SetActive(false);

        if (nail)
            nailObject.SetActive(true);
        else
            nailObject.SetActive(false);
        if (mirror)
            mirrorObject.SetActive(true);
        else
            mirrorObject.SetActive(false);
        RotateToMouse.Instance.pause = false;
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
        player.Instance.ui = false;
        gameObject.SetActive(false);
    }
}