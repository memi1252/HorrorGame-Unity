using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryUI : MonoBehaviour
{
    public static DiaryUI Instance { get; private set; }

    [SerializeField] private Button closeButton;
    
    
    private void Awake()
    {
        Instance = this;
        
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            Time.timeScale = 1;
            RotateToMouse.Instance.anglepause = true;
            RotateToMouse.Instance.pause = true;
        });
    }

    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        player.Instance.h = 0;
        player.Instance.v =0;
    }

    public void Show()
    {
        player.Instance.ui = true;
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.v =0;
        RotateToMouse.Instance.pause = false;
    }


    public void Hide()
    {
        player.Instance.ui = false;
        gameObject.SetActive(false);
        RotateToMouse.Instance.pause = true;
    }
}
