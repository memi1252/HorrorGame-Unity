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

    public void Show()
    {
        gameObject.SetActive(true);
        RotateToMouse.Instance.pause = false;
    }


    public void Hide()
    {
        gameObject.SetActive(false);
        RotateToMouse.Instance.pause = true;
    }
}
