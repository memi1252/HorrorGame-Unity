using UnityEngine;
using UnityEngine.Audio;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance { get; private set; }
    
    [SerializeField] private AudioResource bgm;
    [SerializeField] public AudioResource walk;
    [SerializeField] public AudioResource run;

    [SerializeField] private GameObject playeraudio;


    public AudioSource audioSource;
    public AudioSource runAudioSource;
    public AudioSource walkAudioSource;

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
    }
}