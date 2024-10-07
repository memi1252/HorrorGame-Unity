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

    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
