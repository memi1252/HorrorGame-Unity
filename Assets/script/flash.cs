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
                    light.SetActive(false);
                    soundManager.Instance.lightSwithAudioSource.Play();
                }
                else
                {
                    light.SetActive(true);
                    soundManager.Instance.lightSwithAudioSource.Play();
                }
            }
    }
}