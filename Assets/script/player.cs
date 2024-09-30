using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Profiling.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class player : MonoBehaviour
{
    public static player Instance { get; private set; }
    
    [SerializeField] private int moveSpeed;

    public GameObject itemPos;
    public bool isFlash;
    public bool isEraser;
    
    private RotateToMouse rotateToMouse;
    public bool move = true;
    public bool die;
    float time = 4f;

 
    void Awake()
    {
        Instance = this;
        
        rotateToMouse = GetComponent<RotateToMouse>();
        Time.timeScale = 1;
    }
    
    private void Update()
    {
        Move();
        UpdateRotate();
        Pause();
        Die();
    }
    
    void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotateToMouse.CalculateRotation(mouseX, mouseY);
    }

    void Move()
    {
        if (move)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 moveDir = new Vector3(h, 0, v);

            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 8;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3;
        }
    }

    void Pause(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!storyinteract.Instance.interact)
            {
                if (pauseUI.Instance.gameObject.activeSelf)
                {
                    Time.timeScale = 1;
                    pauseUI.Instance.Hide();
                    RotateToMouse.Instance.anglepause = true;
                    RotateToMouse.Instance.pause = true;
                }
                else
                {
                    Time.timeScale = 0;   
                    pauseUI.Instance.Show();
                    RotateToMouse.Instance.anglepause = false;
                    RotateToMouse.Instance.pause = false;
                }
            }
            if (settingUI.Instance.gameObject.activeSelf)
            {
                settingUI.Instance.Hide();
                Debug.Log(Time.timeScale);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (StoryUI.Instance.gameObject.activeSelf)
            {
                StoryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                storyinteract.Instance.interact = false;
            }
        }
    }

    void Die()
    {
        if (die == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                pauseUI.Instance.pauseUIpasue = true;
                DieUI.Instance.Show();
                RotateToMouse.Instance.pause = false;
                Time.timeScale = 0;
            }
        }
    }
}
