using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundManager : MonoBehaviour
{
    [SerializeField] private AudioResource bgm;
    [SerializeField] public AudioResource walk;
    [SerializeField] public AudioResource run;
    
    [SerializeField] private GameObject playeraudio;


    private AudioSource audioSource;
    private AudioSource walkAudioSource;
    private AudioSource runAudioSource;

    private void Awake()
    {
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
        else if(player.Instance.v == 0 && player.Instance.h == 0)
        {
            if (walkAudioSource.isPlaying)
            {
                walkAudioSource.Stop();
            }
            if (runAudioSource.isPlaying)
            {
                runAudioSource.Stop();
            }
        }
    }

    private void bgmSound()
    {
        audioSource.volume = settingUI.Instance.BGMSlider.value;
    }
}
