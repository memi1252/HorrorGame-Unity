using UnityEngine;
using UnityEngine.Audio;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance { get; private set; }
    
    [SerializeField] private AudioResource bgm;
    [SerializeField] public AudioResource walk;
    [SerializeField] public AudioResource run;
    [SerializeField] public AudioResource lightSwith;
    [SerializeField] public AudioResource boxOpen;

    [SerializeField] private GameObject playeraudio;
    [SerializeField] private GameObject lightaudio;
    [SerializeField] private GameObject boxaudio;


    public AudioSource audioSource;
    public AudioSource runAudioSource;
    public AudioSource walkAudioSource;
    public AudioSource lightSwithAudioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.resource = bgm;
        audioSource.Play();
        audioSource.loop = true;
        walkAudioSource = playeraudio.AddComponent<AudioSource>();
        walkAudioSource.resource = walk;
        runAudioSource = playeraudio.AddComponent<AudioSource>();
        runAudioSource.resource = run;
        lightSwithAudioSource = lightaudio.AddComponent<AudioSource>();
        lightSwithAudioSource.resource = lightSwith;
    }

    private void Update()
    {
        bgmSound();
        effectSound();
        if (player.Instance.v != 0 || player.Instance.h != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!runAudioSource.isPlaying)
                {
                    runAudioSource.Play();
                    walkAudioSource.Stop();
                }
            }
            else
            {
                if (!walkAudioSource.isPlaying)
                {
                    walkAudioSource.Play();
                    runAudioSource.Stop();
                }
            }
        }
        else if (player.Instance.v == 0 && player.Instance.h == 0)
        {
            if (walkAudioSource.isPlaying) walkAudioSource.Stop();
            if (runAudioSource.isPlaying) runAudioSource.Stop();
        }
    }

    private void bgmSound()
    {
        audioSource.volume = settingUI.Instance.BGMSlider.value;
    }
    
    public void effectSound()
    {
        walkAudioSource.volume = settingUI.Instance.EffectSlider.value;
        runAudioSource.volume = settingUI.Instance.EffectSlider.value;
        lightSwithAudioSource.volume = settingUI.Instance.EffectSlider.value;
    }
}