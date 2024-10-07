using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set; }
    
    [SerializeField] private GameObject flashobject;
    [SerializeField] private GameObject eraserobject;
    [SerializeField] private GameObject crossobject;

    public bool flash = false;
    public bool eraser = false;
    public bool cross = false;

    private void Awake()
    {
        Instance = this;
        flashobject.SetActive(false);
        eraserobject.SetActive(false);
        crossobject.SetActive(false);
    }
    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        if (flash)
        {
            flashobject.SetActive(true);
        }   
        if (eraser)
        {
            flashobject.SetActive(true);
        }
        if (cross)
        {
            crossobject.SetActive(true);
        }
        RotateToMouse.Instance.pause = false;
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
