using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set; }
    
    [SerializeField] private GameObject flashObject;
    [SerializeField] private GameObject eraserObject;
    [SerializeField] private GameObject crossObject;
    [SerializeField] private GameObject baseBallObject;
    [SerializeField] private GameObject nailObject;

    public bool flash = false;
    public bool eraser = false;
    public bool cross = false;
    public bool baseBall = false;
    public bool nail = false;

    private void Awake()
    {
        Instance = this;
        flashObject.SetActive(false);
        eraserObject.SetActive(false);
        crossObject.SetActive(false);
        baseBallObject.SetActive(false);
        nailObject.SetActive(false);
    }
    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        player.Instance.h = 0;
        player.Instance.v =0;
        if (flash)
        {
            flashObject.SetActive(true);
        }
        else
        {
            flashObject.SetActive(false);
        }
        if (eraser)
        {
            eraserObject.SetActive(true);
        }
        else
        {
            eraserObject.SetActive(false);
        }
        if (cross)
        {
            crossObject.SetActive(true);
        }
        else
        {
            crossObject.SetActive(false);
        }
        if (baseBall)
        {
            baseBallObject.SetActive(true);
        }
        else
        {
            baseBallObject.SetActive(false);
        }

        if (nail)
        {
            nailObject.SetActive(true);
        }
        else
        {
            nailObject.SetActive(false);
        }
        RotateToMouse.Instance.pause = false;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        player.Instance.h = 0;
        player.Instance.v =0;
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
