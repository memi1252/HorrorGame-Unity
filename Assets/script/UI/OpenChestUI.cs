using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChestUI : MonoBehaviour
{
    public static OpenChestUI Instance { get; private set; }
    [SerializeField] private Button crossBoxButton;
    [SerializeField] private Button flashBoxButton;
    [SerializeField] private Button eraserBoxButton;
    [SerializeField] private Button baseBallBoxButton;
    [SerializeField] private Button nailBoxButton;
    [SerializeField] public Button crossInventoryBoxButton;
    [SerializeField] public Button flashInventoryBoxButton;
    [SerializeField] public Button eraserInventoryBoxButton;
    [SerializeField] public Button baseBallInventoryBoxButton;
    [SerializeField] public Button nailInventoryBoxButton;
    private void Awake()
    {
        Instance = this;
        crossBoxButton.onClick.AddListener(() =>
        {
            crossBoxButton.gameObject.SetActive(false);
            crossInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.cross = true;
        });
        crossInventoryBoxButton.onClick.AddListener(() =>
        {
            crossBoxButton.gameObject.SetActive(true);
            crossInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.cross = false;
        });
        flashBoxButton.onClick.AddListener(() =>
        {
            flashBoxButton.gameObject.SetActive(false);
            flashInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.flash = true;
        });
        flashInventoryBoxButton.onClick.AddListener(() =>
        {
            flashBoxButton.gameObject.SetActive(true);
            flashInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.flash = false;
        });
        eraserBoxButton.onClick.AddListener(() =>
        {
            eraserBoxButton.gameObject.SetActive(false);
            eraserInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.eraser = true;
        });
        eraserInventoryBoxButton.onClick.AddListener(() =>
        {
            eraserBoxButton.gameObject.SetActive(true);
            eraserInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.eraser = false;
        });
        baseBallBoxButton.onClick.AddListener(() =>
        {
            baseBallBoxButton.gameObject.SetActive(false);
            baseBallInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.baseBall = true;
        });
        baseBallInventoryBoxButton.onClick.AddListener(() =>
        {
            baseBallBoxButton.gameObject.SetActive(true);
            baseBallInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.baseBall = false;
        });
        nailBoxButton.onClick.AddListener(() =>
        {
            nailBoxButton.gameObject.SetActive(false);
            nailInventoryBoxButton.gameObject.SetActive(true);
            InventoryUI.Instance.nail = true;
        });
        nailInventoryBoxButton.onClick.AddListener(() =>
        {
            nailBoxButton.gameObject.SetActive(true);
            nailInventoryBoxButton.gameObject.SetActive(false);
            InventoryUI.Instance.nail = false;
        });
        Hide();
    }

    private void Update()
    {
        player.Instance.h = 0;
        player.Instance.v = 0;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
            pauseUI.Instance.Hide();
        }
        if (InventoryUI.Instance.flash)
        {
            flashInventoryBoxButton.gameObject.SetActive(true);
            flash.Instance.gameObject.SetActive(true);
        }
        else
        {
            flashInventoryBoxButton.gameObject.SetActive(false);
            flash.Instance.gameObject.SetActive(false);
        }
        if (InventoryUI.Instance.eraser)
        {
            eraserInventoryBoxButton.gameObject.SetActive(true);
        }
        if (InventoryUI.Instance.cross)
        {
            crossInventoryBoxButton.gameObject.SetActive(true);
        }
        if(InventoryUI.Instance.baseBall)
        {
            baseBallInventoryBoxButton.gameObject.SetActive(true);
        }
    }

    public void Show()
    {
        player.Instance.h = 0;
        player.Instance.v = 0;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}