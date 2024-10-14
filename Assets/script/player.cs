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
    public Animator playerAnimator;
    public bool move = true;
    public bool die;
    public bool ui = false;
    float time = 4f;
    public float h;
    public float v;
    public float mouseX;
    public float mouseY;
    

 
    void Awake()
    {
        Instance = this;
        
        rotateToMouse = GetComponent<RotateToMouse>();
        playerAnimator = GetComponent<Animator>();
        Time.timeScale = 1;
    }
    private void Start()
    {
        settingUI.Instance.BGMSlider.value = PlayerPrefs.GetFloat("BGM");
    }
    
    private void Update()
    {
        Move();
        UpdateRotate();
        Pause();
        Die();
        Inventory();
        ToggleCursorVisibility();
    }
    
    void UpdateRotate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        rotateToMouse.CalculateRotation(mouseX, mouseY);
    }

    void Move()
    {
        if (move)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

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
            if (!storyinteract.Instance.interact && !InventoryUI.Instance.gameObject.activeSelf 
                                                 && !DiaryUI.Instance.gameObject.activeSelf && !DieUI.Instance.gameObject.activeSelf
                                                 && !OpenChestUI.Instance.gameObject.activeSelf && !settingUI.Instance.gameObject.activeSelf
                                                 && !boxUI.Instance.gameObject.activeSelf && !offeringUI.Instance.gameObject.activeSelf)
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
            if (settingUI.Instance.gameObject.activeSelf) {
                settingUI.Instance.Hide();
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
                Time.timeScale = 1;
            }
            if (boxUI.Instance.gameObject.activeSelf)
            {
                if (!BoxInteract.Instance.isShow)
                {
                    boxCloseMonster.Instance.monstershow();
                    story5.Instance.startt();
                    BoxInteract.Instance.isShow = true;
                }
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
                Time.timeScale = 1;
            }
            if (StoryUI.Instance.gameObject.activeSelf)
            {
                StoryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                storyinteract.Instance.interact = false;
            }

            if (InventoryUI.Instance.gameObject.activeSelf)
            {
                InventoryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
            }
            if (DiaryUI.Instance.gameObject.activeSelf)
            {
                DiaryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
            }

            if (OpenChestUI.Instance.gameObject.activeSelf)
            {
                OpenChestUI.Instance.Hide();
                move = true;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
            }

            if (offeringUI.Instance.gameObject.activeSelf)
            {
                offeringUI.Instance.Hide();
                move = true;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
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
                offeringUI.Instance.Hide();
                DieUI.Instance.Show();
                pauseUI.Instance.pauseUIpasue = true;
                RotateToMouse.Instance.pause = false;
                RotateToMouse.Instance.anglepause = false;
                move = false;
                h = 0;
                v = 0;
                Time.timeScale = 0;
            }
        }
    }
    void Inventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryUI.Instance.gameObject.activeSelf)
            {
                InventoryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
            }
            else
            {
                if(!pauseUI.Instance.gameObject.activeSelf && !boxUI.Instance.gameObject.activeSelf
                   && !settingUI.Instance.gameObject.activeSelf && !DiaryUI.Instance.gameObject.activeSelf
                   && !DieUI.Instance.gameObject.activeSelf && !StoryUI.Instance.gameObject.activeSelf 
                   && !OpenChestUI.Instance.gameObject.activeSelf) {
                    InventoryUI.Instance.Show();
                    Time.timeScale = 0;
                    RotateToMouse.Instance.anglepause = false;
                    RotateToMouse.Instance.pause = false;
                }
            }
        }
    }
    void ToggleCursorVisibility()
    {
        if (!ui)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
            {
                RotateToMouse.Instance.pause = false;
                RotateToMouse.Instance.anglepause = false;
            }
            else if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
            {
                RotateToMouse.Instance.pause = true;
                RotateToMouse.Instance.anglepause = true;
            }
        }
    }
}
