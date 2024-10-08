using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryUI : MonoBehaviour
{
    public static DiaryUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
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
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.v =0;
        RotateToMouse.Instance.pause = false;
    }


    public void Hide()
    {
        gameObject.SetActive(false);
        RotateToMouse.Instance.pause = true;
    }
}
