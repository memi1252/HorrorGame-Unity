using UnityEngine;

public class flash : MonoBehaviour
{
    [SerializeField] private GameObject light;


    public bool pickUpFlash;
    public static flash Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        pauseUI.Instance.pauseUIpasue = false;
    }

    private void Update()
    {
        if (pauseUI.Instance.pauseUIpasue == false)
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (light.activeSelf)
                {
                    soundManager.Instance.lightSwithAudioSource.Play();
                    light.SetActive(false);
                }
                else
                {
                    soundManager.Instance.lightSwithAudioSource.Play();
                    light.SetActive(true);
                }
            }
    }
}