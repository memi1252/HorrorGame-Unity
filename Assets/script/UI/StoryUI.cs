using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour
{
    public static StoryUI Instance { get; private set; }

    [SerializeField] private Button playButton;
    [SerializeField] private Button clostButton;

    private void Awake()
    {
        Instance = this;
        
        playButton.onClick.AddListener(() =>
        {
            Hide();
            Time.timeScale = 1;
            RotateToMouse.Instance.anglepause = true;
            flash.Instance.pickUpFlash = false;
            SceneManager.LoadScene("Map");
        });
        clostButton.onClick.AddListener(() =>
        {
            Hide();
            Time.timeScale = 1;
            RotateToMouse.Instance.anglepause = true;
        });
    }

    private void Update()
    {
        player.Instance.h = 0;
        player.Instance.v =0;
    }

    private void Start()
    {
        Hide();
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
