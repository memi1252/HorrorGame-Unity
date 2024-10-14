using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingUI : MonoBehaviour
{
    public static settingUI Instance { get; private set; }
    
    [SerializeField] public Slider BGMSlider;

    private void Awake()
    {
        Instance = this;
        Hide();
    }

    private void Update()
    {
        player.Instance.h = 0;
        player.Instance.v =0;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.ui = true;
        player.Instance.v =0;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
