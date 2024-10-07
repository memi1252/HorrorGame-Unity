using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundManager : MonoBehaviour
{
    [SerializeField] private AudioResource bgm;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.resource = bgm;
        audioSource.Play();
        audioSource.loop = true;
    }

    private void Update()
    {
        bgmSound();
    }

    private void bgmSound()
    {
        audioSource.volume = settingUI.Instance.BGMSlider.value;
    }
}
