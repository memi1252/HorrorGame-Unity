using Unity.VisualScripting;
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
    [SerializeField] public AudioResource mirrorpush;
    [SerializeField] public AudioResource itemPickUp;
    [SerializeField] private AudioResource itemDrop;

    [SerializeField] private GameObject playeraudio;
    [SerializeField] public GameObject lightaudio;
    [SerializeField] public GameObject box1audio;


    public AudioSource audioSource;
    public AudioSource runAudioSource;
    public AudioSource walkAudioSource;
    public AudioSource lightSwithAudioSource;
    public AudioSource box1AudioSource;
    public AudioSource mirrorAudioSource;
    public AudioSource itemPickUpAudioSource;
    public AudioSource itemDropAudioSource;
    

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
        box1AudioSource = box1audio.AddComponent<AudioSource>();
        box1AudioSource.resource = boxOpen;
        mirrorAudioSource = transform.AddComponent<AudioSource>();
        mirrorAudioSource.resource = mirrorpush;
        itemPickUpAudioSource = transform.AddComponent<AudioSource>();
        itemPickUpAudioSource.resource = itemPickUp;
        itemDropAudioSource = transform.AddComponent<AudioSource>();
        itemDropAudioSource.resource = itemDrop;
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
        if(walkAudioSource != null)
            walkAudioSource.volume = settingUI.Instance.EffectSlider.value;
        if(runAudioSource != null)
            runAudioSource.volume = settingUI.Instance.EffectSlider.value;
        if(lightSwithAudioSource != null)
            lightSwithAudioSource.volume = settingUI.Instance.EffectSlider.value;
        if(box1AudioSource != null)
            box1AudioSource.volume = settingUI.Instance.EffectSlider.value + 0.5f;
        if(mirrorAudioSource != null)
            mirrorAudioSource.volume = settingUI.Instance.EffectSlider.value -0.15f;
        if(itemPickUpAudioSource != null)
            itemPickUpAudioSource.volume = settingUI.Instance.EffectSlider.value + 0.5f;
        if(itemDropAudioSource != null)
            itemDropAudioSource.volume = settingUI.Instance.EffectSlider.value + 0.5f;
    }
}